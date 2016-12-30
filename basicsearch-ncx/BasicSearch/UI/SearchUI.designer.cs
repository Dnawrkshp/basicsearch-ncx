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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.PbScanProgress = new BasicSearch.UI.SearchProgressBar();
            this.BtStopScan = new MetroFramework.Controls.MetroButton();
            this.BtBeginScan = new MetroFramework.Controls.MetroButton();
            this.LabStopAddress = new MetroFramework.Controls.MetroLabel();
            this.LabStartAddress = new MetroFramework.Controls.MetroLabel();
            this.LabScanDataType = new MetroFramework.Controls.MetroLabel();
            this.LabScanMethod = new MetroFramework.Controls.MetroLabel();
            this.TbStopAddress = new MetroFramework.Controls.MetroTextBox();
            this.TbStartAddress = new MetroFramework.Controls.MetroTextBox();
            this.CbScanMethod = new MetroFramework.Controls.MetroComboBox();
            this.CbScanDataType = new MetroFramework.Controls.MetroComboBox();
            this.ResultBox = new BasicSearch.UI.AddressListBox();
            this.MetroToolTip1 = new MetroFramework.Components.MetroToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).BeginInit();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.IsSplitterFixed = true;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.ResultBox);
            this.SplitContainer1.Size = new System.Drawing.Size(885, 639);
            this.SplitContainer1.SplitterDistance = 193;
            this.SplitContainer1.TabIndex = 0;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.IsSplitterFixed = true;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            this.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.PbScanProgress);
            this.SplitContainer2.Panel1.Controls.Add(this.BtStopScan);
            this.SplitContainer2.Panel1.Controls.Add(this.BtBeginScan);
            this.SplitContainer2.Panel1.Controls.Add(this.LabStopAddress);
            this.SplitContainer2.Panel1.Controls.Add(this.LabStartAddress);
            this.SplitContainer2.Panel1.Controls.Add(this.LabScanDataType);
            this.SplitContainer2.Panel1.Controls.Add(this.LabScanMethod);
            this.SplitContainer2.Panel1.Controls.Add(this.TbStopAddress);
            this.SplitContainer2.Panel1.Controls.Add(this.TbStartAddress);
            this.SplitContainer2.Panel1.Controls.Add(this.CbScanMethod);
            this.SplitContainer2.Panel1.Controls.Add(this.CbScanDataType);
            this.SplitContainer2.Size = new System.Drawing.Size(885, 193);
            this.SplitContainer2.SplitterDistance = 110;
            this.SplitContainer2.TabIndex = 0;
            // 
            // PbScanProgress
            // 
            this.PbScanProgress.HideProgressText = false;
            this.PbScanProgress.LeftText = "";
            this.PbScanProgress.Location = new System.Drawing.Point(174, 82);
            this.PbScanProgress.Name = "PbScanProgress";
            this.PbScanProgress.Size = new System.Drawing.Size(699, 23);
            this.PbScanProgress.TabIndex = 0;
            // 
            // BtStopScan
            // 
            this.BtStopScan.Enabled = false;
            this.BtStopScan.Location = new System.Drawing.Point(93, 82);
            this.BtStopScan.Name = "BtStopScan";
            this.BtStopScan.Size = new System.Drawing.Size(75, 23);
            this.BtStopScan.TabIndex = 10;
            this.BtStopScan.Tag = "";
            this.BtStopScan.Text = "Stop";
            this.BtStopScan.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.BtStopScan, "Stop running scan.");
            this.BtStopScan.UseSelectable = true;
            this.BtStopScan.Click += new System.EventHandler(this.BtStopScan_Click);
            // 
            // BtBeginScan
            // 
            this.BtBeginScan.Location = new System.Drawing.Point(12, 82);
            this.BtBeginScan.Name = "BtBeginScan";
            this.BtBeginScan.Size = new System.Drawing.Size(75, 23);
            this.BtBeginScan.TabIndex = 9;
            this.BtBeginScan.Tag = "";
            this.BtBeginScan.Text = "Start Initial";
            this.BtBeginScan.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.BtBeginScan, "Begin scan.");
            this.BtBeginScan.UseSelectable = true;
            this.BtBeginScan.Click += new System.EventHandler(this.BtBeginScan_Click);
            // 
            // LabStopAddress
            // 
            this.LabStopAddress.AutoSize = true;
            this.LabStopAddress.BackColor = System.Drawing.Color.Transparent;
            this.LabStopAddress.Location = new System.Drawing.Point(606, 52);
            this.LabStopAddress.Name = "LabStopAddress";
            this.LabStopAddress.Size = new System.Drawing.Size(87, 19);
            this.LabStopAddress.TabIndex = 7;
            this.LabStopAddress.Text = "Stop Address";
            this.LabStopAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LabStopAddress.UseCustomBackColor = true;
            // 
            // LabStartAddress
            // 
            this.LabStartAddress.AutoSize = true;
            this.LabStartAddress.BackColor = System.Drawing.Color.Transparent;
            this.LabStartAddress.Location = new System.Drawing.Point(605, 16);
            this.LabStartAddress.Name = "LabStartAddress";
            this.LabStartAddress.Size = new System.Drawing.Size(88, 19);
            this.LabStartAddress.TabIndex = 6;
            this.LabStartAddress.Text = "Start Address";
            this.LabStartAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LabStartAddress.UseCustomBackColor = true;
            // 
            // LabScanDataType
            // 
            this.LabScanDataType.AutoSize = true;
            this.LabScanDataType.BackColor = System.Drawing.Color.Transparent;
            this.LabScanDataType.Location = new System.Drawing.Point(28, 52);
            this.LabScanDataType.Name = "LabScanDataType";
            this.LabScanDataType.Size = new System.Drawing.Size(70, 19);
            this.LabScanDataType.TabIndex = 5;
            this.LabScanDataType.Text = "Value Type";
            this.LabScanDataType.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LabScanDataType.UseCustomBackColor = true;
            // 
            // LabScanMethod
            // 
            this.LabScanMethod.AutoSize = true;
            this.LabScanMethod.BackColor = System.Drawing.Color.Transparent;
            this.LabScanMethod.Location = new System.Drawing.Point(12, 16);
            this.LabScanMethod.Name = "LabScanMethod";
            this.LabScanMethod.Size = new System.Drawing.Size(86, 19);
            this.LabScanMethod.TabIndex = 4;
            this.LabScanMethod.Text = "Scan Method";
            this.LabScanMethod.Theme = MetroFramework.MetroThemeStyle.Light;
            this.LabScanMethod.UseCustomBackColor = true;
            // 
            // TbStopAddress
            // 
            // 
            // 
            // 
            this.TbStopAddress.CustomButton.Image = null;
            this.TbStopAddress.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.TbStopAddress.CustomButton.Name = "";
            this.TbStopAddress.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TbStopAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbStopAddress.CustomButton.TabIndex = 1;
            this.TbStopAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbStopAddress.CustomButton.UseSelectable = true;
            this.TbStopAddress.CustomButton.Visible = false;
            this.TbStopAddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TbStopAddress.Lines = new string[] {
        "00000000"};
            this.TbStopAddress.Location = new System.Drawing.Point(697, 47);
            this.TbStopAddress.MaxLength = 32767;
            this.TbStopAddress.Name = "TbStopAddress";
            this.TbStopAddress.PasswordChar = '\0';
            this.TbStopAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbStopAddress.SelectedText = "";
            this.TbStopAddress.SelectionLength = 0;
            this.TbStopAddress.SelectionStart = 0;
            this.TbStopAddress.ShortcutsEnabled = true;
            this.TbStopAddress.ShowClearButton = true;
            this.TbStopAddress.Size = new System.Drawing.Size(176, 29);
            this.TbStopAddress.TabIndex = 3;
            this.TbStopAddress.Text = "00000000";
            this.TbStopAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.TbStopAddress, "Stop address of scan.");
            this.TbStopAddress.UseSelectable = true;
            this.TbStopAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbStopAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TbStartAddress
            // 
            // 
            // 
            // 
            this.TbStartAddress.CustomButton.Image = null;
            this.TbStartAddress.CustomButton.Location = new System.Drawing.Point(148, 1);
            this.TbStartAddress.CustomButton.Name = "";
            this.TbStartAddress.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.TbStartAddress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TbStartAddress.CustomButton.TabIndex = 1;
            this.TbStartAddress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TbStartAddress.CustomButton.UseSelectable = true;
            this.TbStartAddress.CustomButton.Visible = false;
            this.TbStartAddress.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.TbStartAddress.Lines = new string[] {
        "00000000"};
            this.TbStartAddress.Location = new System.Drawing.Point(697, 12);
            this.TbStartAddress.MaxLength = 32767;
            this.TbStartAddress.Name = "TbStartAddress";
            this.TbStartAddress.PasswordChar = '\0';
            this.TbStartAddress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TbStartAddress.SelectedText = "";
            this.TbStartAddress.SelectionLength = 0;
            this.TbStartAddress.SelectionStart = 0;
            this.TbStartAddress.ShortcutsEnabled = true;
            this.TbStartAddress.ShowClearButton = true;
            this.TbStartAddress.Size = new System.Drawing.Size(176, 29);
            this.TbStartAddress.TabIndex = 2;
            this.TbStartAddress.Text = "00000000";
            this.TbStartAddress.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.TbStartAddress, "Start address of scan.");
            this.TbStartAddress.UseSelectable = true;
            this.TbStartAddress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TbStartAddress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CbScanMethod
            // 
            this.CbScanMethod.FormattingEnabled = true;
            this.CbScanMethod.ItemHeight = 23;
            this.CbScanMethod.Location = new System.Drawing.Point(104, 12);
            this.CbScanMethod.Name = "CbScanMethod";
            this.CbScanMethod.PromptText = "Scan Method";
            this.CbScanMethod.Size = new System.Drawing.Size(495, 29);
            this.CbScanMethod.TabIndex = 1;
            this.CbScanMethod.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.CbScanMethod, "Scan Method.");
            this.CbScanMethod.UseSelectable = true;
            this.CbScanMethod.SelectedIndexChanged += new System.EventHandler(this.CbScanMethod_SelectedIndexChanged);
            // 
            // CbScanDataType
            // 
            this.CbScanDataType.FormattingEnabled = true;
            this.CbScanDataType.ItemHeight = 23;
            this.CbScanDataType.Location = new System.Drawing.Point(104, 47);
            this.CbScanDataType.Name = "CbScanDataType";
            this.CbScanDataType.PromptText = "Scan Value Type";
            this.CbScanDataType.Size = new System.Drawing.Size(495, 29);
            this.CbScanDataType.TabIndex = 0;
            this.CbScanDataType.Theme = MetroFramework.MetroThemeStyle.Light;
            this.MetroToolTip1.SetToolTip(this.CbScanDataType, "Scan Data Type.");
            this.CbScanDataType.UseSelectable = true;
            this.CbScanDataType.SelectedIndexChanged += new System.EventHandler(this.CbScanDataType_SelectedIndexChanged);
            // 
            // ResultBox
            // 
            this.ResultBox.AllowSorting = true;
            this.ResultBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ResultBox.FullRowSelect = true;
            this.ResultBox.GridLines = true;
            this.ResultBox.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ResultBox.HideSelection = false;
            this.ResultBox.LabelWrap = false;
            this.ResultBox.List = null;
            this.ResultBox.Location = new System.Drawing.Point(0, 0);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.OwnerDraw = true;
            this.ResultBox.Size = new System.Drawing.Size(885, 442);
            this.ResultBox.TabIndex = 0;
            this.ResultBox.Type = null;
            this.ResultBox.UseCompatibleStateImageBehavior = false;
            this.ResultBox.UseSelectable = true;
            this.ResultBox.View = System.Windows.Forms.View.Details;
            this.ResultBox.VirtualMode = true;
            // 
            // MetroToolTip1
            // 
            this.MetroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.MetroToolTip1.StyleManager = null;
            this.MetroToolTip1.Theme = MetroFramework.MetroThemeStyle.Default;
            // 
            // SearchUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 639);
            this.Controls.Add(this.SplitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SearchUI";
            this.Text = "Basic Scanner";
            this.Resize += new System.EventHandler(this.SearchUI_Resize);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer1)).EndInit();
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer2)).EndInit();
            this.SplitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer1;
        private System.Windows.Forms.SplitContainer SplitContainer2;
        private MetroFramework.Controls.MetroTextBox TbStartAddress;
        private MetroFramework.Controls.MetroComboBox CbScanMethod;
        private MetroFramework.Controls.MetroComboBox CbScanDataType;
        private MetroFramework.Controls.MetroTextBox TbStopAddress;
        private MetroFramework.Controls.MetroLabel LabScanMethod;
        private MetroFramework.Controls.MetroLabel LabScanDataType;
        private MetroFramework.Controls.MetroLabel LabStopAddress;
        private MetroFramework.Controls.MetroLabel LabStartAddress;
        private MetroFramework.Controls.MetroButton BtStopScan;
        private MetroFramework.Controls.MetroButton BtBeginScan;
        private MetroFramework.Components.MetroToolTip MetroToolTip1;
        private AddressListBox ResultBox;
        private SearchProgressBar PbScanProgress;
    }
}
