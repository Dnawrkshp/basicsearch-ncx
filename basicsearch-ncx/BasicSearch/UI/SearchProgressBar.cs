using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Controls;
using MetroFramework.Drawing;
using System.Windows.Forms;

namespace BasicSearch.UI
{
    public class SearchProgressBar : MetroProgressBar
    {
        private MetroLabel _label = new MetroLabel();
        private string _leftText = "";

        public string LeftText
        {
            get { return _leftText; }
            set { _leftText = value; _label.Text = _leftText; }
        }

        public SearchProgressBar()
        {
            this.HideProgressText = false;
            this.Controls.Add(_label);

            _label.AutoSize = false;
            _label.Location = new System.Drawing.Point(0, 0);
            _label.Size = this.Size;
            _label.BackColor = System.Drawing.Color.Transparent;
            _label.UseCustomBackColor = true;
            _label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.Resize += SearchProgressBar_Resize;
        }

        private void SearchProgressBar_Resize(object sender, EventArgs e)
        {
            _label.Size = this.Size;
        }
    }
}
