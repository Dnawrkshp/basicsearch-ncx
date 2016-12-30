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
    public partial class sbyteControl : UserControl
    {
        // Value of numericUpDown for public access
        public sbyte Value
        {
            get { return (sbyte)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
        }

        public sbyteControl()
        {
            InitializeComponent();

            numericUpDown1.IsSigned = true;
            numericUpDown1.Minimum = sbyte.MinValue;
            numericUpDown1.Maximum = sbyte.MaxValue;
            numericUpDown1.Value = 0;
        }
    }
}
