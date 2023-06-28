namespace KioskCore
{
    partial class Configuration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.browseButton = new System.Windows.Forms.Button();
            this.browseLabel = new System.Windows.Forms.Label();
            this.taskbarCheckBox = new System.Windows.Forms.CheckBox();
            this.hourComboBox = new System.Windows.Forms.ComboBox();
            this.minuteComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.reopenCheckBox = new System.Windows.Forms.CheckBox();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.intervalComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ctrlEscCheckBox = new System.Windows.Forms.CheckBox();
            this.bringForwardCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(12, 12);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // browseLabel
            // 
            this.browseLabel.AutoSize = true;
            this.browseLabel.Location = new System.Drawing.Point(93, 17);
            this.browseLabel.Name = "browseLabel";
            this.browseLabel.Size = new System.Drawing.Size(175, 13);
            this.browseLabel.TabIndex = 1;
            this.browseLabel.Text = "Select the program you want to run.";
            // 
            // taskbarCheckBox
            // 
            this.taskbarCheckBox.AutoSize = true;
            this.taskbarCheckBox.Location = new System.Drawing.Point(12, 134);
            this.taskbarCheckBox.Name = "taskbarCheckBox";
            this.taskbarCheckBox.Size = new System.Drawing.Size(90, 17);
            this.taskbarCheckBox.TabIndex = 2;
            this.taskbarCheckBox.Text = "Hide Taskbar";
            this.taskbarCheckBox.UseVisualStyleBackColor = true;
            // 
            // hourComboBox
            // 
            this.hourComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.hourComboBox.FormattingEnabled = true;
            this.hourComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hourComboBox.Location = new System.Drawing.Point(12, 219);
            this.hourComboBox.Name = "hourComboBox";
            this.hourComboBox.Size = new System.Drawing.Size(40, 21);
            this.hourComboBox.TabIndex = 6;
            // 
            // minuteComboBox
            // 
            this.minuteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.minuteComboBox.FormattingEnabled = true;
            this.minuteComboBox.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.minuteComboBox.Location = new System.Drawing.Point(66, 219);
            this.minuteComboBox.Name = "minuteComboBox";
            this.minuteComboBox.Size = new System.Drawing.Size(40, 21);
            this.minuteComboBox.TabIndex = 7;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(311, 270);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(91, 29);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save Settings";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // reopenCheckBox
            // 
            this.reopenCheckBox.AutoSize = true;
            this.reopenCheckBox.Location = new System.Drawing.Point(12, 65);
            this.reopenCheckBox.Name = "reopenCheckBox";
            this.reopenCheckBox.Size = new System.Drawing.Size(168, 17);
            this.reopenCheckBox.TabIndex = 9;
            this.reopenCheckBox.Text = "Reopen program when closed";
            this.reopenCheckBox.UseVisualStyleBackColor = true;
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Location = new System.Drawing.Point(12, 88);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(355, 17);
            this.logCheckBox.TabIndex = 10;
            this.logCheckBox.Text = "Save KioskCoreLog.txt in Documents (Takes notes on actions taken.)";
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // intervalComboBox
            // 
            this.intervalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalComboBox.FormattingEnabled = true;
            this.intervalComboBox.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "15",
            "30",
            "60",
            "120"});
            this.intervalComboBox.Location = new System.Drawing.Point(12, 274);
            this.intervalComboBox.Name = "intervalComboBox";
            this.intervalComboBox.Size = new System.Drawing.Size(46, 21);
            this.intervalComboBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(53, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Shutdown Time (HH:MM)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Check Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Minute";
            // 
            // ctrlEscCheckBox
            // 
            this.ctrlEscCheckBox.AutoSize = true;
            this.ctrlEscCheckBox.Location = new System.Drawing.Point(12, 111);
            this.ctrlEscCheckBox.Name = "ctrlEscCheckBox";
            this.ctrlEscCheckBox.Size = new System.Drawing.Size(144, 17);
            this.ctrlEscCheckBox.TabIndex = 16;
            this.ctrlEscCheckBox.Text = "Block Ctrl + Esc Shortcut";
            this.ctrlEscCheckBox.UseVisualStyleBackColor = true;
            // 
            // bringForwardCheckBox
            // 
            this.bringForwardCheckBox.AutoSize = true;
            this.bringForwardCheckBox.Location = new System.Drawing.Point(12, 157);
            this.bringForwardCheckBox.Name = "bringForwardCheckBox";
            this.bringForwardCheckBox.Size = new System.Drawing.Size(259, 17);
            this.bringForwardCheckBox.TabIndex = 17;
            this.bringForwardCheckBox.Text = "Bring the program forward each time it is checked";
            this.bringForwardCheckBox.UseVisualStyleBackColor = true;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 311);
            this.Controls.Add(this.bringForwardCheckBox);
            this.Controls.Add(this.ctrlEscCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervalComboBox);
            this.Controls.Add(this.logCheckBox);
            this.Controls.Add(this.reopenCheckBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.minuteComboBox);
            this.Controls.Add(this.hourComboBox);
            this.Controls.Add(this.taskbarCheckBox);
            this.Controls.Add(this.browseLabel);
            this.Controls.Add(this.browseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(900, 350);
            this.MinimumSize = new System.Drawing.Size(430, 350);
            this.Name = "Configuration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KioskCore";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label browseLabel;
        private System.Windows.Forms.CheckBox taskbarCheckBox;
        private System.Windows.Forms.ComboBox hourComboBox;
        private System.Windows.Forms.ComboBox minuteComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.CheckBox reopenCheckBox;
        private System.Windows.Forms.CheckBox logCheckBox;
        private System.Windows.Forms.ComboBox intervalComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ctrlEscCheckBox;
        private System.Windows.Forms.CheckBox bringForwardCheckBox;
    }
}

