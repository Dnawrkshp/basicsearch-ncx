using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.Containers;
using MetroFramework.Controls;
using MetroFramework;
using NetCheatX.Core;
using NetCheatX.Core.Basic;
using System.Diagnostics;

namespace BasicSearch.UI
{
    public class AddressListBox : MetroListView
    {
        private static Font EffectiveFont = MetroFramework.MetroFonts.Label(MetroLabelSize.Tall, MetroLabelWeight.Light);
        private static Brush MetroBlue = MetroFramework.Drawing.MetroPaint.GetStyleBrush(MetroFramework.MetroColorStyle.Blue);
        private static Brush MetroBlack = MetroFramework.Drawing.MetroPaint.GetStyleBrush(MetroFramework.MetroColorStyle.Black);
        

        private bool _isUserColumnWidthChange = true;

        private ISearchType _type = null;
        private SearchResultContainer<ISearchResult> _list = null;
        private Stopwatch _stopWatch = null;
        private MetroTextBox _textBox = null;

        public SearchResultContainer<ISearchResult> List
        {
            get { return _list; }
            set
            {
                if (_list != null)
                    _list.SearchResultUpdated -= ResultUpdated;

                _list = value;

                if (_list != null)
                {
                    _list.SearchResultUpdated += ResultUpdated;
                }
            }
        }

        public ISearchType Type
        {
            get { return _type; }
            set
            {
                // We don't support changing the type while there are results
                if (_list != null && _list.Count() > 0)
                    return;

                _type = value;

                PopulateColumns();
            }
        }

        public AddressListBox()
        {
            OwnerDraw = true;
            View = View.Details;
            VirtualMode = true;

            _stopWatch = new Stopwatch();
            _textBox = new MetroTextBox() { Visible = false };
            _textBox.LostFocus += TextBox_LostFocus;
            _textBox.GotFocus += TextBox_GotFocus;
            this.Controls.Add(_textBox);


            this.RetrieveVirtualItem += AddressListBox_RetrieveVirtualItem;
            this.ColumnWidthChanging += AddressListBox_ColumnWidthChanging;
            this.MouseDoubleClick += AddressListBox_MouseDoubleClick;
        }

        #region Draw

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            if (Type == null || Type.Columns == null)
                return;

            e.DrawBackground();

            e.Graphics.FillRectangle(MetroBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Gray, e.Bounds);

            int stringWidth = (int)e.Graphics.MeasureString(e.Header.Text, EffectiveFont).Width;
            e.Graphics.DrawString(e.Header.Text, EffectiveFont, MetroBlack, new Point(e.Bounds.Location.X + (e.Header.TextAlign == HorizontalAlignment.Right?(e.Header.Width-stringWidth):(e.Header.TextAlign == HorizontalAlignment.Center?((e.Header.Width-stringWidth)/2):0)), e.Bounds.Location.Y));
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            if (e.ItemIndex >= 0 && e.ColumnIndex >= 0)
            {
                e.DrawBackground();

                if (e.Item.Selected)
                    e.Graphics.FillRectangle(MetroBlue, e.Bounds);

                if (e.ItemIndex < _list.Count && Type != null)
                    TextRenderer.DrawText(e.Graphics, e.Item.SubItems[e.ColumnIndex].Text, Fonts.UbuntuMono.UbuntuMonoRegular, e.Bounds, this.ForeColor, flags);
            }
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < _list.Count && Type != null && e.Item.Selected)
            {
                Rectangle rowBounds = e.Bounds;
                int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left;
                Rectangle bounds = new Rectangle(leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
                e.Graphics.FillRectangle(MetroBlue, bounds);
            }
            else
                e.DrawDefault = false;
        }

        #endregion

        #region Misc Events

        private void AddressListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.SelectedIndices.Count != 1)
                return;

            ListViewItem item = this.Items[this.SelectedIndices[0]];
            ListViewItem.ListViewSubItem subitem = item.GetSubItemAt(e.X, e.Y);

            _textBox.Size = subitem.Bounds.Size;
            if (subitem.Bounds.Width == item.Bounds.Width)
            {
                for (int x = 1; x < item.SubItems.Count; x++)
                    _textBox.Width -= item.SubItems[x].Bounds.Width;
            }

            _textBox.Text = subitem.Text;
            _textBox.Location = subitem.Bounds.Location;
            _textBox.TextAlign = HorizontalAlignment.Center;
            _textBox.Font = Fonts.UbuntuMono.UbuntuMonoRegular;
            _textBox.Visible = true;
            _textBox.BringToFront();
            _textBox.Focus();
            
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            _textBox.Visible = false;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            _textBox.Visible = true;
        }

        private void ResultUpdated(object sender, Types.SearchResultUpdatedEventArgs[] e)
        {
            if (!_stopWatch.IsRunning)
            {
                _stopWatch.Start();
            }
            else if (_stopWatch.ElapsedMilliseconds > 1000)
            {
                _stopWatch.Restart();
            }
            else
            {
                return;
            }


            Invoke((MethodInvoker)delegate
            {
                this.VirtualListSize = _list.Count;
            });
        }

        private void AddressListBox_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < _list.Count && Type != null)
            {
                Type.ProcessResult(out string[] i, _list[e.ItemIndex]);
                if (i != null)
                    e.Item = new ListViewItem(i);
            }
            else
            {
                e.Item = new ListViewItem(new string[this.Columns.Count]);
            }

            if (_list.Count < this.VirtualListSize)
            {
                this.BeginUpdate();
                this.VirtualListSize = _list.Count;
                this.SetScrollPosition(0);
                this.EndUpdate();
            }
        }

        private void AddressListBox_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (!_isUserColumnWidthChange)
                return;

            _isUserColumnWidthChange = false;

            int MaxW = this.Width - this.Margin.Left - this.Margin.Right;

            if (AdjustColumn(e.ColumnIndex + 1, MaxW, 40))
            {
                for (int x = 0; x < this.Columns.Count; x++)
                    if (x != e.ColumnIndex)
                        MaxW -= this.Columns[x].Width;
                this.Columns[e.ColumnIndex].Width = MaxW;
            }

            _isUserColumnWidthChange = true;
        }

        #endregion

        #region Private Functions

        private void PopulateColumns()
        {
            if (Type != null && Type.Columns != null)
            {
                Invoke((MethodInvoker)delegate
                {
                    this.Columns.Clear();

                    int width = this.Width / Type.Columns.Length;
                    foreach (string column in Type.Columns)
                        this.Columns.Add(column, width, HorizontalAlignment.Center);
                });
            }
        }

        private bool AdjustColumn(int index, int MaxW, int MinW)
        {
            int newWidth = MaxW;
            for (int x = 0; x < this.Columns.Count; x++)
            {
                if (x == index)
                    continue;

                newWidth -= this.Columns[x].Width;
            }

            if (newWidth < MinW)
                newWidth = MinW;

            this.Columns[index].Width = newWidth;
            if (index == (this.Columns.Count - 1))
                return true;

            return AdjustColumn(index + 1, MaxW, MinW);
        }

        #endregion

        #region Public Functions

        public void Reset()
        {
            this.VirtualListSize = 0;
            Application.DoEvents();
            this._list.Clear();

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        #endregion

        #region Scan

        public void ScanFirst(ISearchType type, ISearchMethod method, Types.MemoryRange[] ranges, object[] args, Types.SetProgressCallback setProgress)
        {
            if (_list == null)
            {
                throw new Exception("Results list is null on start of initial scan.");
            }

            PopulateColumns();
            method.FirstScan(ref _list, type, args, ranges, setProgress);

            this._stopWatch.Stop();
            Invoke((MethodInvoker)delegate
            {
                this.VirtualListSize = _list.Count;
            });
        }

        #endregion

    }
}
