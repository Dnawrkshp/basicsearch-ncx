﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicSearch.SearchParamEditor.UI
{
    public partial class ulongControl : UserControl
    {
        // Value of numericUpDown for public access
        public ulong Value
        {
            get { return (ulong)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public ulongControl()
        {
            InitializeComponent();

            numericUpDown1.Minimum = ulong.MinValue;
            numericUpDown1.Maximum = ulong.MaxValue;
            numericUpDown1.Value = 0;
        }
    }
}
