namespace BasicSearch.UI
{
    partial class SearchUI
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btStopScan = new MetroFramework.Controls.MetroButton();
            this.btBeginScan = new MetroFramework.Controls.MetroButton();
            this.pbScanProgress = new MetroFramework.Controls.MetroProgressBar();
            this.labStopAddress = new MetroFramework.Controls.MetroLabel();
            this.labStartAddress = new MetroFramework.Controls.MetroLabel();
            this.labScanDataType = new MetroFramework.Controls.MetroLabel();
            this.labScanMethod = new MetroFramework.Controls.MetroLabel();
            this.tbStopAddress = new MetroFramework.Controls.MetroTextBox();
            this.tbStartAddress = new MetroFramework.Controls.MetroTextBox();
            this.cbScanMethod = new MetroFramework.Controls.MetroComboBox();
            this.cbScanDataType = new MetroFramework.Controls.MetroComboBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(885, 639);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btStopScan);
            this.splitContainer2.Panel1.Controls.Add(this.btBeginScan);
            this.splitContainer2.Panel1.Controls.Add(this.pbScanProgress);
            this.splitContainer2.Panel1.Controls.Add(this.labStopAddress);
            this.splitContainer2.Panel1.Controls.Add(this.labStartAddress);
            this.splitContainer2.Panel1.Controls.Add(this.labScanDataType);
            this.splitContainer2.Panel1.Controls.Add(this.labScanMethod);
            this.splitContainer2.Panel1.Controls.Add(this.tbStopAddress);
            this.splitContainer2.Panel1.Controls.Add(this.tbStartAddress);
            this.splitContainer2.Panel1.Controls.Add(this.cbScanMethod);
            this.splitContainer2.Panel1.Controls.Add(this.cbScanDataType);
            this.splitContainer2.Size = new System.Drawing.Size(885, 193);
            this.splitContainer2.SplitterDistance = 110;
            this.splitContainer2.TabIndex = 0;
            // 
            // btStopScan
            // 
            this.btStopScan.Location = new System.Drawing.Point(93, 82);
            this.btStopScan.Name = "btStopScan";
            this.btStopScan.Size = new System.Drawing.Size(75, 23);
            this.btStopScan.TabIndex = 10;
            this.btStopScan.Tag = "";
            this.btStopScan.Text = "Stop";
            this.btStopScan.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.btStopScan, "Stop running scan.");
            this.btStopScan.UseSelectable = true;
            this.btStopScan.Click += new System.EventHandler(this.btStopScan_Click);
            // 
            // btBeginScan
            // 
            this.btBeginScan.Location = new System.Drawing.Point(12, 82);
            this.btBeginScan.Name = "btBeginScan";
            this.btBeginScan.Size = new System.Drawing.Size(75, 23);
            this.btBeginScan.TabIndex = 9;
            this.btBeginScan.Tag = "";
            this.btBeginScan.Text = "Start Initial";
            this.btBeginScan.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.btBeginScan, "Begin scan.");
            this.btBeginScan.UseSelectable = true;
            this.btBeginScan.Click += new System.EventHandler(this.btBeginScan_Click);
            // 
            // pbScanProgress
            // 
            this.pbScanProgress.HideProgressText = false;
            this.pbScanProgress.Location = new System.Drawing.Point(174, 82);
            this.pbScanProgress.Name = "pbScanProgress";
            this.pbScanProgress.Size = new System.Drawing.Size(699, 23);
            this.pbScanProgress.TabIndex = 8;
            this.pbScanProgress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.pbScanProgress, "Scan progress.");
            this.pbScanProgress.Value = 20;
            // 
            // labStopAddress
            // 
            this.labStopAddress.AutoSize = true;
            this.labStopAddress.BackColor = System.Drawing.Color.Transparent;
            this.labStopAddress.Location = new System.Drawing.Point(606, 52);
            this.labStopAddress.Name = "labStopAddress";
            this.labStopAddress.Size = new System.Drawing.Size(87, 19);
            this.labStopAddress.TabIndex = 7;
            this.labStopAddress.Text = "Stop Address";
            this.labStopAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.labStopAddress.UseCustomBackColor = true;
            // 
            // labStartAddress
            // 
            this.labStartAddress.AutoSize = true;
            this.labStartAddress.BackColor = System.Drawing.Color.Transparent;
            this.labStartAddress.Location = new System.Drawing.Point(605, 16);
            this.labStartAddress.Name = "labStartAddress";
            this.labStartAddress.Size = new System.Drawing.Size(88, 19);
            this.labStartAddress.TabIndex = 6;
            this.labStartAddress.Text = "Start Address";
            this.labStartAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.labStartAddress.UseCustomBackColor = true;
            // 
            // labScanDataType
            // 
            this.labScanDataType.AutoSize = true;
            this.labScanDataType.BackColor = System.Drawing.Color.Transparent;
            this.labScanDataType.Location = new System.Drawing.Point(28, 52);
            this.labScanDataType.Name = "labScanDataType";
            this.labScanDataType.Size = new System.Drawing.Size(70, 19);
            this.labScanDataType.TabIndex = 5;
            this.labScanDataType.Text = "Value Type";
            this.labScanDataType.Theme = MetroFramework.MetroThemeStyle.Light;
            this.labScanDataType.UseCustomBackColor = true;
            // 
            // labScanMethod
            // 
            this.labScanMethod.AutoSize = true;
            this.labScanMethod.BackColor = System.Drawing.Color.Transparent;
            this.labScanMethod.Location = new System.Drawing.Point(12, 16);
            this.labScanMethod.Name = "labScanMethod";
            this.labScanMethod.Size = new System.Drawing.Size(86, 19);
            this.labScanMethod.TabIndex = 4;
            this.labScanMethod.Text = "Scan Method";
            this.labScanMethod.Theme = MetroFramework.MetroThemeStyle.Light;
            this.labScanMethod.UseCustomBackColor = true;
            // 
            // tbStopAddress
            // 
            // 
            // 
            // 
            this.tbStopAddress.CustomButton.Image = null;
            this.tbStopAddress.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.tbStopAddress.CustomButton.Name = "";
            this.tbStopAddress.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.tbStopAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbStopAddress.CustomButton.TabIndex = 1;
            this.tbStopAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbStopAddress.CustomButton.UseSelectable = true;
            this.tbStopAddress.CustomButton.Visible = false;
            this.tbStopAddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbStopAddress.Lines = new string[] {
        "00000000"};
            this.tbStopAddress.Location = new System.Drawing.Point(697, 47);
            this.tbStopAddress.MaxLength = 32767;
            this.tbStopAddress.Name = "tbStopAddress";
            this.tbStopAddress.PasswordChar = '\0';
            this.tbStopAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbStopAddress.SelectedText = "";
            this.tbStopAddress.SelectionLength = 0;
            this.tbStopAddress.SelectionStart = 0;
            this.tbStopAddress.ShortcutsEnabled = true;
            this.tbStopAddress.ShowClearButton = true;
            this.tbStopAddress.Size = new System.Drawing.Size(176, 29);
            this.tbStopAddress.TabIndex = 3;
            this.tbStopAddress.Text = "00000000";
            this.tbStopAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.tbStopAddress, "Stop address of scan.");
            this.tbStopAddress.UseSelectable = true;
            this.tbStopAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbStopAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbStartAddress
            // 
            // 
            // 
            // 
            this.tbStartAddress.CustomButton.Image = null;
            this.tbStartAddress.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.tbStartAddress.CustomButton.Name = "";
            this.tbStartAddress.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.tbStartAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbStartAddress.CustomButton.TabIndex = 1;
            this.tbStartAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbStartAddress.CustomButton.UseSelectable = true;
            this.tbStartAddress.CustomButton.Visible = false;
            this.tbStartAddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.tbStartAddress.Lines = new string[] {
        "00000000"};
            this.tbStartAddress.Location = new System.Drawing.Point(697, 12);
            this.tbStartAddress.MaxLength = 32767;
            this.tbStartAddress.Name = "tbStartAddress";
            this.tbStartAddress.PasswordChar = '\0';
            this.tbStartAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbStartAddress.SelectedText = "";
            this.tbStartAddress.SelectionLength = 0;
            this.tbStartAddress.SelectionStart = 0;
            this.tbStartAddress.ShortcutsEnabled = true;
            this.tbStartAddress.ShowClearButton = true;
            this.tbStartAddress.Size = new System.Drawing.Size(176, 29);
            this.tbStartAddress.TabIndex = 2;
            this.tbStartAddress.Text = "00000000";
            this.tbStartAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.tbStartAddress, "Start address of scan.");
            this.tbStartAddress.UseSelectable = true;
            this.tbStartAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbStartAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // cbScanMethod
            // 
            this.cbScanMethod.FormattingEnabled = true;
            this.cbScanMethod.ItemHeight = 23;
            this.cbScanMethod.Location = new System.Drawing.Point(104, 12);
            this.cbScanMethod.Name = "cbScanMethod";
            this.cbScanMethod.PromptText = "Scan Method";
            this.cbScanMethod.Size = new System.Drawing.Size(495, 29);
            this.cbScanMethod.TabIndex = 1;
            this.cbScanMethod.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.cbScanMethod, "Scan Method.");
            this.cbScanMethod.UseSelectable = true;
            this.cbScanMethod.SelectedIndexChanged += new System.EventHandler(this.cbScanMethod_SelectedIndexChanged);
            // 
            // cbScanDataType
            // 
            this.cbScanDataType.FormattingEnabled = true;
            this.cbScanDataType.ItemHeight = 23;
            this.cbScanDataType.Location = new System.Drawing.Point(104, 47);
            this.cbScanDataType.Name = "cbScanDataType";
            this.cbScanDataType.PromptText = "Scan Value Type";
            this.cbScanDataType.Size = new System.Drawing.Size(495, 29);
            this.cbScanDataType.TabIndex = 0;
            this.cbScanDataType.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.cbScanDataType, "Scan Data Type.");
            this.cbScanDataType.UseSelectable = true;
            this.cbScanDataType.SelectedIndexChanged += new System.EventHandler(this.cbScanDataType_SelectedIndexChanged);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // SearchUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 639);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchUI";
            this.Text = "Basic Scanner";
            this.Resize += new System.EventHandler(this.SearchUI_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private MetroFramework.Controls.MetroTextBox tbStartAddress;
        private MetroFramework.Controls.MetroComboBox cbScanMethod;
        private MetroFramework.Controls.MetroComboBox cbScanDataType;
        private MetroFramework.Controls.MetroTextBox tbStopAddress;
        private MetroFramework.Controls.MetroLabel labScanMethod;
        private MetroFramework.Controls.MetroLabel labScanDataType;
        private MetroFramework.Controls.MetroLabel labStopAddress;
        private MetroFramework.Controls.MetroLabel labStartAddress;
        private MetroFramework.Controls.MetroProgressBar pbScanProgress;
        private MetroFramework.Controls.MetroButton btStopScan;
        private MetroFramework.Controls.MetroButton btBeginScan;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
    }
}