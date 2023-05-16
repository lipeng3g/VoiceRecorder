using NAudio.Lame;
using NAudio.Wave;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace VoiceRecorder
{
    public class DeviceItem
    {
        public ProgressBar Progress { get; set; }
        public CheckBox Name { get; set; }
        public WaveInCapabilities Device { get; set; }
        public IWaveIn WaveIn { get; set; }
        public Stream StreamWriter { get; set; }
        public string Folder { get; set; }
        public int MaxDb { get; set; }
        public int MinDb { get; set; }
        public string StreamPath { get; set; }

        public Stream CreateStreamWriter()
        {
            var nameFixed = Regex.Replace(Name.Text, "[^a-zA-Z0-9]", "");
            var filename = $@"{DateTime.Now:yyyyMMdd}_{DateTime.Now:HHmmss}_{nameFixed}.mp3";
            var pathfile = Path.Combine(Folder, filename);
            StreamPath = pathfile;
            var format = new WaveFormat(44100, 1);
            this.StreamWriter = new LameMP3FileWriter(pathfile, WaveIn.WaveFormat, LAMEPreset.ABR_96);
            return this.StreamWriter;
        }

        public void SaveInfo() 
        {
            if (String.IsNullOrEmpty(StreamPath))
            {
                return;
            }
            string filePath = Path.Combine(Folder, "DbInfo.txt"); 

            // 使用锁确保只有一个线程可以访问文件
            lock (filePath)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($@"{StreamPath}___{MinDb}___{MaxDb}");
                }
            }
        }
    }
}
