﻿namespace BasicSearch.SearchParamEditor.UI
{
    partial class ulongControl
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
            this.numericUpDown1 = new BasicSearch.SearchParamEditor.UI.MetroUpDown();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 0;
            this.numericUpDown1.Hexadecimal = true;
            this.numericUpDown1.HexButton = true;
            this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            -1,
            2147483647,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(174, 28);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            -7,
            2147483647,
            0,
            0});
            // 
            // ulongControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Name = "ulongControl";
            this.Size = new System.Drawing.Size(174, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroUpDown numericUpDown1;
    }
}