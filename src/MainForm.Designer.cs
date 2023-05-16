namespace VoiceRecorder
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panDevices = new System.Windows.Forms.Panel();
            this.btnRecord = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxCycle = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownCycle = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxClean = new System.Windows.Forms.CheckBox();
            this.buttonClean = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownClean = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.timerCycle = new System.Windows.Forms.Timer(this.components);
            this.timerClean = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycle)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClean)).BeginInit();
            this.SuspendLayout();
            // 
            // panDevices
            // 
            this.panDevices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDevices.Location = new System.Drawing.Point(16, 246);
            this.panDevices.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panDevices.Name = "panDevices";
            this.panDevices.Size = new System.Drawing.Size(400, 331);
            this.panDevices.TabIndex = 2;
            // 
            // btnRecord
            // 
            this.btnRecord.BackColor = System.Drawing.Color.Black;
            this.btnRecord.ImageIndex = 0;
            this.btnRecord.ImageList = this.imageList1;
            this.btnRecord.Location = new System.Drawing.Point(16, 14);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(212, 78);
            this.btnRecord.TabIndex = 3;
            this.btnRecord.UseVisualStyleBackColor = false;
            this.btnRecord.Click += new System.EventHandler(this.BtnRecord_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Record.png");
            this.imageList1.Images.SetKeyName(1, "stop.png");
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(236, 37);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(143, 37);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "00:00:00";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(241, 18);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(111, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Not recording";
            // 
            // btnPath
            // 
            this.btnPath.Image = ((System.Drawing.Image)(resources.GetObject("btnPath.Image")));
            this.btnPath.Location = new System.Drawing.Point(354, 20);
            this.btnPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(37, 30);
            this.btnPath.TabIndex = 6;
            this.btnPath.UseVisualStyleBackColor = true;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(7, 22);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(345, 25);
            this.txtPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "循环录制：";
            // 
            // checkBoxCycle
            // 
            this.checkBoxCycle.AutoSize = true;
            this.checkBoxCycle.Location = new System.Drawing.Point(105, 62);
            this.checkBoxCycle.Name = "checkBoxCycle";
            this.checkBoxCycle.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCycle.TabIndex = 9;
            this.checkBoxCycle.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "音频时长(秒)：";
            // 
            // numericUpDownCycle
            // 
            this.numericUpDownCycle.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCycle.Location = new System.Drawing.Point(263, 56);
            this.numericUpDownCycle.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCycle.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCycle.Name = "numericUpDownCycle";
            this.numericUpDownCycle.Size = new System.Drawing.Size(120, 25);
            this.numericUpDownCycle.TabIndex = 11;
            this.numericUpDownCycle.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "定时删除：";
            // 
            // checkBoxClean
            // 
            this.checkBoxClean.AutoSize = true;
            this.checkBoxClean.Location = new System.Drawing.Point(105, 101);
            this.checkBoxClean.Name = "checkBoxClean";
            this.checkBoxClean.Size = new System.Drawing.Size(15, 14);
            this.checkBoxClean.TabIndex = 13;
            this.checkBoxClean.UseVisualStyleBackColor = true;
            // 
            // buttonClean
            // 
            this.buttonClean.Location = new System.Drawing.Point(324, 90);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(68, 32);
            this.buttonClean.TabIndex = 14;
            this.buttonClean.Text = "手动删";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownClean);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPath);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.buttonClean);
            this.groupBox1.Controls.Add(this.checkBoxClean);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numericUpDownCycle);
            this.groupBox1.Controls.Add(this.checkBoxCycle);
            this.groupBox1.Location = new System.Drawing.Point(19, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 127);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置项";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "DB被删除";
            // 
            // numericUpDownClean
            // 
            this.numericUpDownClean.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownClean.Location = new System.Drawing.Point(182, 96);
            this.numericUpDownClean.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownClean.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownClean.Name = "numericUpDownClean";
            this.numericUpDownClean.Size = new System.Drawing.Size(62, 25);
            this.numericUpDownClean.TabIndex = 16;
            this.numericUpDownClean.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "低于";
            // 
            // timerCycle
            // 
            this.timerCycle.Interval = 1000;
            this.timerCycle.Tick += new System.EventHandler(this.timerCycle_Tick);
            // 
            // timerClean
            // 
            this.timerClean.Enabled = true;
            this.timerClean.Interval = 600000;
            this.timerClean.Tick += new System.EventHandler(this.timerClean_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 589);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.panDevices);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(447, 2300);
            this.MinimumSize = new System.Drawing.Size(447, 85);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceRecorder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCycle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClean)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panDevices;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxCycle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownCycle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxClean;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownClean;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timerCycle;
        private System.Windows.Forms.Timer timerClean;
    }
}

