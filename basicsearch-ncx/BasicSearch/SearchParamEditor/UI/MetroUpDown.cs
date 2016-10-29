using System;
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
    public partial class MetroUpDown : UserControl
    {
        private decimal _value = 0;
        private int _decimalPlaces = 0;
        private int _hexPlaces = 0;
        private bool _hex = false;
        private decimal _minValue = 0;
        private decimal _maxValue = 100;
        private bool _hexButton = false;

        public bool HexButton
        {
            get { return _hexButton; }
            set
            {
                _hexButton = value;
                metroTextBox1.ShowButton = _hexButton;
            }
        }

        public decimal Minimum
        {
            get { return _minValue; }
            set
            {
                if (value > _maxValue) // invalid
                    return;

                _minValue = value;

                if (Value < _minValue)
                    Value = _minValue;
            }
        }

        public decimal Maximum
        {
            get { return _maxValue; }
            set
            {
                if (value < _minValue) // invalid
                    return;

                _maxValue = value;

                if (Value > _maxValue)
                    Value = _maxValue;

                if (_maxValue <= byte.MaxValue)
                    _hexPlaces = 2;
                else if (_maxValue <= ushort.MaxValue)
                    _hexPlaces = 4;
                else if (_maxValue <= uint.MaxValue)
                    _hexPlaces = 8;
                else
                    _hexPlaces = 16;
            }
        }

        public bool Hexadecimal
        {
            get { return _hex; }
            set
            {
                _hex = value;
                metroTextBox1.CustomButton.Image = Hexadecimal ? Properties.Resources.Hex : Properties.Resources.Decimal;
                UpdateText();
            }
        }

        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set { _decimalPlaces = value; if (!Hexadecimal) { UpdateText(); } }
        }

        public decimal Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (_value > _maxValue)
                    _value = _maxValue;
                else if (_value < _minValue)
                    _value = _minValue;
                UpdateText();
            }
        }

        public MetroUpDown()
        {
            InitializeComponent();

            
            if (HexButton)
                metroTextBox1.CustomButton.Image = Hexadecimal ? Properties.Resources.Hex : Properties.Resources.Decimal;

            metroTextBox1.CustomButton.Click += CustomButton_Click;
        }

        private void UpdateText()
        {
            int selStart = metroTextBox1.SelectionStart;

            if (Hexadecimal)
            {
                switch (_hexPlaces)
                {
                    case 2: // 1 byte
                        if (_minValue < 0)
                            metroTextBox1.Text = ((sbyte)_value).ToString("X" + _hexPlaces.ToString());
                        else
                            metroTextBox1.Text = ((byte)_value).ToString("X" + _hexPlaces.ToString());
                        break;
                    case 4: // 2 bytes
                        if (_minValue < 0)
                            metroTextBox1.Text = ((short)_value).ToString("X" + _hexPlaces.ToString());
                        else
                            metroTextBox1.Text = ((ushort)_value).ToString("X" + _hexPlaces.ToString());
                        break;
                    case 8: // 4 bytes
                        if (_minValue < 0)
                            metroTextBox1.Text = ((int)_value).ToString("X" + _hexPlaces.ToString());
                        else
                            metroTextBox1.Text = ((uint)_value).ToString("X" + _hexPlaces.ToString());
                        break;
                    case 16: // 8 bytes
                    default:
                        if (_minValue < 0)
                            metroTextBox1.Text = ((long)_value).ToString("X" + _hexPlaces.ToString());
                        else
                            metroTextBox1.Text = ((ulong)_value).ToString("X" + _hexPlaces.ToString());
                        break;

                }
            }
            else
            {
                metroTextBox1.Text = _value.ToString("0." + new string('#', DecimalPlaces));
            }

            metroTextBox1.SelectionStart = selStart;
        }

        private void ValidateNewText(string text)
        {
            try
            {
                if (Hexadecimal)
                    _value = (decimal)Convert.ToUInt64(text, 16);
                else
                    _value = decimal.Parse(text);
            }
            catch
            {
                UpdateText();
                return;
            }

            // Ensure value is as appears in text
            Value = Math.Round(_value, DecimalPlaces, MidpointRounding.AwayFromZero);
        }

        private void metroUpDown_Resize(object sender, EventArgs e)
        {
            this.metroTextBox1.Size = this.Size;
        }

        private void metroTextBox1_Validating(object sender, CancelEventArgs e)
        {
            ValidateNewText(metroTextBox1.Text);
        }

        private void metroTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                ValidateNewText(metroTextBox1.Text);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                Value += 1;
                e.Handled = true;
                metroTextBox1.SelectionStart = metroTextBox1.Text.Length;
            }
            else if (e.KeyCode == Keys.Down)
            {
                Value -= 1;
                e.Handled = true;
                metroTextBox1.SelectionStart = metroTextBox1.Text.Length;
            }
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            Hexadecimal = !Hexadecimal;
        }

        private void metroTextBox1_ClearClicked()
        {
            Value = 0;
            UpdateText();
            metroTextBox1.SelectionStart = metroTextBox1.Text.Length;
        }
    }
}
