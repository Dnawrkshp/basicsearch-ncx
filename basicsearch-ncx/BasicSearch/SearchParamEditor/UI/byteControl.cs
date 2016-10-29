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
    public partial class byteControl : UserControl
    {
        // Value of numericUpDown for public access
        public byte Value
        {
            get { return (byte)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public byteControl()
        {
            InitializeComponent();

            numericUpDown1.Minimum = byte.MinValue;
            numericUpDown1.Maximum = byte.MaxValue;
            numericUpDown1.Value = 0;
        }
    }
}
