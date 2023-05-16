using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VoiceRecorder
{
    public partial class MainForm : Form
    {
        private bool _isRecording = false;
        private Stopwatch _watcher = new Stopwatch();
        private Timer _timer = new Timer() { Interval = 1000 };
        private List<DeviceItem> _allDevices = new List<DeviceItem>();
        private string _path;
        const int IMAGE_RECORD = 0;
        const int IMAGE_STOP = 1;

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"Voice Recorder - v{Assembly.GetExecutingAssembly().GetName().Version.ToString(2)}";

            _path = GetDefaultFolder();
            txtPath.Text = _path;

            StartListeningAllDevices();


            _timer.Tick += (sender, e) => { lblTime.Text = $@"{_watcher.Elapsed:hh\:mm\:ss}"; };
            _timer.Start();
        }

        private void StartListeningAllDevices()
        {
            // System sound
            var deviceSystem = AddDeviceToPanel(-1);
            StartListening(deviceSystem);

            // Connected Devices
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var device = AddDeviceToPanel(i);
                StartListening(device);
            }
        }

        private void StopListeningAllDevices()
        {
            foreach (var item in _allDevices)
            {
                item.WaveIn.StopRecording();
            }

            _allDevices.Clear();
        }

        private void StartListening(DeviceItem device)
        {
            _allDevices.Add(device);

            device.WaveIn.DataAvailable += (sender, e) =>
            {
                // Save in the WAV
                if (_isRecording && device.Name.Checked)
                {
                    if (device.StreamWriter == null)
                        device.CreateStreamWriter();

                    device.StreamWriter.Write(e.Buffer, 0, e.BytesRecorded);
                }
                int db = Convert.ToInt32(100 * GetPeakValue(e) / (float)int.MaxValue);
                WriteProgressSafe(device.Progress, db);
                device.MaxDb = device.MaxDb > db ? device.MaxDb : db;
                device.MinDb = device.MinDb < db ? device.MinDb : db;
            };

            device.WaveIn.RecordingStopped += (sender, e) =>
            {
                device.StreamWriter?.Dispose();
                device.StreamWriter = null;
                device.WaveIn.Dispose();
                device.WaveIn = null;
            };

            device.WaveIn.StartRecording();
        }

        private DeviceItem AddDeviceToPanel(int index)
        {
            const int ITEMS_MARGIN = 30;
            bool isSystemDevice = index < 0;

            var device = isSystemDevice ? default(WaveInCapabilities) : WaveIn.GetCapabilities(index);
            var deviceName = isSystemDevice ? "System" : device.ProductName;

            // Checkox with device name
            var chkDeviceName = new CheckBox()
            {
                Left = 0,
                Top = (2 * index + 2) * ITEMS_MARGIN + 4,
                AutoSize = true,
                Text = deviceName,
                Checked = true
            };

            // Progress bar to display the Voice Peak
            var pgbDevice = new ProgressBar()
            {
                Left = 0,
                Top = (2 * index + 3) * ITEMS_MARGIN,
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Width = 265
            };

            // WaveIn
            IWaveIn waveIn;
            if (isSystemDevice)
                waveIn = new WasapiLoopbackCapture();
            else
                waveIn = new WaveInEvent()
                {
                    WaveFormat = new WaveFormat(44100, 2),
                    DeviceNumber = index
                };

            panDevices.Controls.Add(chkDeviceName);
            panDevices.Controls.Add(pgbDevice);

            return new DeviceItem()
            {
                Name = chkDeviceName,
                Progress = pgbDevice,
                Device = device,
                WaveIn = waveIn,
                Folder = _path,
                MaxDb = 0,
                MinDb = 0,
            };
        }

        private float GetPeakValue(WaveInEventArgs args)
        {
            int max = 0;
            int sample = 0;

            var buffer = new WaveBuffer(args.Buffer);
            // interpret as 32 bit floating point audio
            for (int index = 0; index < args.BytesRecorded / 4; index++)
            {
                sample = buffer.IntBuffer[index];

                // absolute value 
                if (sample < 0) sample = -sample;
                // is this the max value?
                if (sample > max) max = sample;
            }

            return max;
        }

        private delegate void SafeCallDelegate(ProgressBar progress, int value);

        private void WriteProgressSafe(ProgressBar progress, int value)
        {
            try
            {
                if (progress.InvokeRequired)
                {
                    var d = new SafeCallDelegate(WriteProgressSafe);
                    Invoke(d, new object[] { progress, value });
                }
                else
                {
                    progress.Value = value;
                }
            }
            catch (Exception)
            {
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListeningAllDevices();
        }

        private void StartRecord()
        {
            if (!_isRecording)
            {
                // Start the record
                _watcher.Restart();
                btnRecord.ImageIndex = IMAGE_STOP;
                btnRecord.BackColor = System.Drawing.Color.Red;
                lblStatus.Text = "Recording";
                _isRecording = true;

                checkBoxClean.Enabled = false;
                checkBoxCycle.Enabled = false;
                numericUpDownClean.Enabled = false;
                numericUpDownCycle.Enabled = false;
                buttonClean.Enabled = false;

                timerClean.Interval = (int)(numericUpDownClean.Value * 1000);
                timerCycle.Interval = (int)(numericUpDownCycle.Value * 1000);
                if (timerClean.Enabled)
                { 
                    timerClean.Start();
                }
                if (timerCycle.Enabled) 
                { 
                    timerCycle.Start();
                }
            }
        }

        private void StopRecord()
        {
            if (_isRecording)
            {
                // Stop the record
                _watcher.Stop();
                btnRecord.ImageIndex = IMAGE_RECORD;
                btnRecord.BackColor = System.Drawing.Color.Black;
                lblStatus.Text = "Not recording";
                _isRecording = false;

                checkBoxClean.Enabled = true;
                checkBoxCycle.Enabled = true;
                numericUpDownClean.Enabled = true;
                numericUpDownCycle.Enabled = true;
                buttonClean.Enabled = true;

                foreach (var item in _allDevices)
                {
                    if (item.StreamWriter != null)
                    {
                        item.StreamWriter.Close();
                        item.StreamWriter.Dispose();
                        item.StreamWriter = null;
                    }
                    item.SaveInfo();
                    //重置最大最小值
                    item.MaxDb = 0;
                    item.MinDb = 0;
                }

                Process.Start(_path);
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {

            if (_isRecording)
            {
                // Stop the record
                StopRecord();
            }
            else
            {
                // Start the record
                StartRecord();
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            string prevpath = folderBrowserDialog1.SelectedPath;
            folderBrowserDialog1.Reset();
            folderBrowserDialog1.SelectedPath = _path;
            folderBrowserDialog1.ShowNewFolderButton = true;

            var dr = folderBrowserDialog1.ShowDialog();
            if (dr == DialogResult.OK || dr == DialogResult.Yes)
            {
                StopListeningAllDevices();
                _path = folderBrowserDialog1.SelectedPath;
                txtPath.Text = _path;
                StartListeningAllDevices();
            }
            folderBrowserDialog1.SelectedPath = prevpath;
        }


        private string GetDefaultFolder()
        {
            var _folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _folder = Path.Combine(_folder, "VoiceRecorder");

            try
            {
                // If the directory doesn't exist, create it.
                if (!Directory.Exists(_folder))
                {
                    Directory.CreateDirectory(_folder);
                }
            }
            catch (Exception)
            {
                // merdouille silently
            }

            return _folder;
        }

        private void timerCycle_Tick(object sender, EventArgs e)
        {
            StopRecord();
            StartRecord();
        }

        private void timerClean_Tick(object sender, EventArgs e)
        {
            string filePath = Path.Combine(_path, "DbInfo.txt");
            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在：" + filePath);
                return;
            }
            lock (filePath)
            {
                string[] lines = File.ReadAllLines(filePath);
                string[] parts;
                for (int i = 0; i < lines.Length; i++)
                {
                    parts = lines[i].Split(new string[] { "___" }, StringSplitOptions.None);
                    if (parts.Length != 3)
                    {
                        Console.WriteLine("数据格式不正确：" + lines[i]);
                        continue;
                    }

                    int minValue = 0;
                    if (Int32.TryParse(parts[1], out minValue) && minValue < numericUpDownClean.Value)
                    {
                        if (File.Exists(parts[0]))
                        {
                            File.Delete(parts[0]);
                        }
                        lines[i] = null;
                    }
                }

                string tempFilePath = Path.Combine(_path, "_temp.txt");
                using (StreamWriter sw = new StreamWriter(tempFilePath))
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i] != null)
                        {
                            sw.WriteLine(lines[i]);
                        }
                    }
                }
                File.Delete(filePath);
                File.Move(tempFilePath, filePath);
            }
        }
    }
}
