namespace BasicSearch.SearchParamEditor.UI
{
    partial class stringControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.textBox1 = new MetroFramework.Controls.MetroTextBox();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(190, -1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(14, 30);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroToolTip1.SetToolTip(this.checkBox1, "UTF8 Text.");
            this.checkBox1.UseCustomBackColor = true;
            this.checkBox1.UseSelectable = true;
            // 
            // textBox1
            // 
            // 
            // 
            // 
            this.textBox1.CustomButton.Image = null;
            this.textBox1.CustomButton.Location = new System.Drawing.Point(162, 2);
            this.textBox1.CustomButton.Name = "";
            this.textBox1.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.textBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox1.CustomButton.TabIndex = 1;
            this.textBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.CustomButton.UseSelectable = true;
            this.textBox1.CustomButton.Visible = false;
            this.textBox1.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectedText = "";
            this.textBox1.SelectionLength = 0;
            this.textBox1.SelectionStart = 0;
            this.textBox1.ShortcutsEnabled = true;
            this.textBox1.ShowClearButton = true;
            this.textBox1.Size = new System.Drawing.Size(188, 28);
            this.textBox1.TabIndex = 2;
            this.textBox1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox1.UseSelectable = true;
            this.textBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // stringControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBox1);
            this.Name = "stringControl";
            this.Size = new System.Drawing.Size(204, 29);
            this.Resize += new System.EventHandler(this.stringControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroCheckBox checkBox1;
        private MetroFramework.Controls.MetroTextBox textBox1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
    }
}
