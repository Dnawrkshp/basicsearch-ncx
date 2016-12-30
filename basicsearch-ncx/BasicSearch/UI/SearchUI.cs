using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;
using NetCheatX.Core.Extensions;
using System.Threading;

namespace BasicSearch.UI
{
    public partial class SearchUI : NetCheatX.Core.UI.XForm
    {
        #region Private Vars

        private bool _isUserInput = true;
        private Types.SearchMode _scanState = Types.SearchMode.First;
        private Thread _searchThread;

        private AddOn.SearchUIAddOn _searchUIAddOn = null;
        private IPluginHost _host = null;
        private NetCheatX.Core.Containers.SearchResultContainer<ISearchResult> _searchResults = new NetCheatX.Core.Containers.SearchResultContainer<ISearchResult>();
        private bool _isFirstScan = true;

        // Tooltip text for each ISearchMethod and ISearchType
        private Dictionary<ISearchMethod, string> _cbScanMethodToolTips = new Dictionary<ISearchMethod, string>();
        private Dictionary<ISearchType, string> _cbScanDataTypeToolTips = new Dictionary<ISearchType, string>();

        private Dictionary<string, UserControl> _typeEditorControls = new Dictionary<string, UserControl>();

        #endregion

        #region Enumerations

        public enum GetScanArgsResult
        {
            NO_SCAN_METHOD,
            NO_SCAN_TYPE,
            INVALID_ADDRESS_RANGE,
            INVALID_PARAMETER,
            SUCCESS
        }

        #endregion

        public SearchUI(IPluginHost host, AddOn.SearchUIAddOn searchUIAddOn)
        {
            CBItem item;

            _searchUIAddOn = searchUIAddOn;
            _host = host;

            InitializeComponent();

            this.Shown += SearchUI_Shown;

            CbScanMethod.Items.Clear();
            CbScanDataType.Items.Clear();

            // Setup data type and method combo boxes
            foreach (ISearchMethod sm in host.SearchMethods)
            {
                if (sm.Mode == Types.SearchMode.First || sm.Mode == Types.SearchMode.Both)
                {
                    item = new UI.CBItem(sm);
                    this.CbScanMethod.Items.Add(item);
                    _cbScanMethodToolTips.Add(sm, item.ToTooltip());
                }
            }

            foreach (ISearchType st in host.SearchTypes)
            {
                item = new UI.CBItem(st);
                this.CbScanDataType.Items.Add(item);
                _cbScanDataTypeToolTips.Add(st, item.ToTooltip());
            }
        }

        #region Event Handlers

        private void SearchUI_Shown(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void SearchUI_Resize(object sender, EventArgs e)
        {
            PbScanProgress.Width = this.Width - 202;
        }

        private void CbScanMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroToolTip1.SetToolTip(CbScanMethod, "Scan Method.");

            int i = CbScanMethod.SelectedIndex;
            if (i < 0)
                return;

            if (i < _host.SearchMethods.Count)
                MetroToolTip1.SetToolTip(CbScanMethod, _cbScanMethodToolTips[(ISearchMethod)(CbScanMethod.SelectedItem as CBItem).Plugin]);

            if (_isUserInput)
            {
                // Update parameters
                if (CbScanDataType.SelectedIndex >= 0)
                    UpdateParameters((ISearchMethod)(CbScanMethod.SelectedItem as CBItem).Plugin, (ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin);

                _isUserInput = false;
                UpdateSearchTypes((ISearchMethod)(CbScanMethod.SelectedItem as CBItem).Plugin);
                _isUserInput = true;
            }
        }

        private void CbScanDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetroToolTip1.SetToolTip(CbScanDataType, "Scan Data Type.");

            int i = CbScanDataType.SelectedIndex;
            if (i < 0)
                return;

            if (i < _host.SearchTypes.Count)
                MetroToolTip1.SetToolTip(CbScanDataType, _cbScanDataTypeToolTips[(ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin]);

            if (_isUserInput)
            {
                // Update parameters
                if (CbScanMethod.SelectedIndex >= 0)
                    UpdateParameters((ISearchMethod)(CbScanMethod.SelectedItem as CBItem).Plugin, (ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin);

                _isUserInput = false;
                UpdateSearchMethods((ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin);
                _isUserInput = true;
            }

            this.ResultBox.Type = (ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin;
        }

        private void BtBeginScan_Click(object sender, EventArgs e)
        {
            if (!_host.ActiveCommunicator.Ready)
            {
                MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], "Please initialize the " + _host.ActiveCommunicator.Name + " before attempting to scan.", "Communicator is not ready!");
                return;
            }

            GetScanArgsResult result = GetScanArgs(out ISearchType type, out var method, out ulong start, out ulong stop, out var param);
            if (result != GetScanArgsResult.SUCCESS)
            {
                MetroFramework.MetroMessageBox.Show(Application.OpenForms["Display"], result.ToString(), "Scan failed");
                return;
            }

            SetSettings();
            if (_scanState == Types.SearchMode.First)
            {
                _searchThread = new Thread(() => { if (_host.ActiveCommunicator.Reconnect()) { ScanFirst(type, method, start, stop, param); } else { } })
                {
                    IsBackground = true
                };
                _searchThread.Start();
            }
            else
            {

            }
        }

        private void BtStopScan_Click(object sender, EventArgs e)
        {
            if (this.BtStopScan.Text == "New Scan")
            {
                this.ResultBox.Reset();

                this.BtBeginScan.Text = "Start Initial";
                this.BtBeginScan.Enabled = true;
                this.BtStopScan.Text = "Stop";
                this.BtStopScan.Enabled = false;
                this._scanState = Types.SearchMode.First;
            }
            else if (this.BtStopScan.Text == "Stop")
            {

            }
        }

        #endregion

        #region Private Functions

        // Get Settings
        private void GetSettings()
        {
            string s = _host.PlatformProperties["BasicSearch_SearchUI_LastStart"];
            if (s != null && s != "")
                TbStartAddress.Text = s;
            else
                _host.PlatformProperties["BasicSearch_SearchUI_LastStart"] = TbStartAddress.Text;

            s = _host.PlatformProperties["BasicSearch_SearchUI_LastStop"];
            if (s != null && s != "")
                TbStopAddress.Text = s;
            else
                _host.PlatformProperties["BasicSearch_SearchUI_LastStop"] = TbStopAddress.Text;

            s = _host.PlatformProperties["BasicSearch_SearchUI_LastMethod"];
            if (s != null && s != "")
            {
                for (int x = 0; x < CbScanMethod.Items.Count; x++)
                {
                    if ((CbScanMethod.Items[x] as CBItem).Plugin.ToBase64String() == s)
                    {
                        CbScanMethod.SelectedIndex = x;
                        break;
                    }
                }
            }

            s = _host.PlatformProperties["BasicSearch_SearchUI_LastType"];
            if (s != null && s != "")
            {
                for (int x = 0; x < CbScanDataType.Items.Count; x++)
                {
                    if ((CbScanDataType.Items[x] as CBItem).Plugin.ToBase64String() == s)
                    {
                        CbScanDataType.SelectedIndex = x;
                        break;
                    }
                }
            }
        }

        // Set settings
        private void SetSettings()
        {
            _host.PlatformProperties["BasicSearch_SearchUI_LastStart"] = TbStartAddress.Text;
            _host.PlatformProperties["BasicSearch_SearchUI_LastStop"] = TbStopAddress.Text;
            _host.PlatformProperties["BasicSearch_SearchUI_LastMethod"] = (CbScanMethod.SelectedItem as CBItem).Plugin.ToBase64String();
            _host.PlatformProperties["BasicSearch_SearchUI_LastType"] = (CbScanDataType.SelectedItem as CBItem).Plugin.ToBase64String();
        }

        // Begin first scan
        private void ScanFirst(ISearchType type, ISearchMethod method, ulong start, ulong stop, object[] param)
        {
            Invoke((MethodInvoker)delegate
            {
                this.BtBeginScan.Enabled = false;
                this.BtStopScan.Text = "Stop";
                this.BtStopScan.Enabled = true;
                this.ResultBox.List = new NetCheatX.Core.Containers.SearchResultContainer<ISearchResult>();
            });

            this.ResultBox.ScanFirst(type, method, new Types.MemoryRange[] { new Types.MemoryRange() { start = start, stop = stop } }, param, (p,v,m,t) => { if (method == p) { try { Invoke((MethodInvoker)delegate { this.PbScanProgress.LeftText = t; this.PbScanProgress.Maximum = 100; this.PbScanProgress.Value = (int)(100f * ((float)v / (float)m)); }); } catch (Exception e) { } } });

            Invoke((MethodInvoker)delegate
            {
                this.BtBeginScan.Text = "Next Scan";
                this.BtBeginScan.Enabled = true;
                this.BtStopScan.Text = "New Scan";
            });

            this._scanState = Types.SearchMode.Next;
        }

        // Get all search arguments
        private GetScanArgsResult GetScanArgs(out ISearchType type, out ISearchMethod method, out ulong start, out ulong stop, out object[] param)
        {
            Types.SearchParam sParam;
            ITypeEditor editor;
            int i;

            type = null;
            method = null;
            start = 0;
            stop = 0;
            param = null;

            // Check we have Scan Type and Method selected
            if (CbScanDataType.SelectedIndex < 0)
                return GetScanArgsResult.NO_SCAN_TYPE;
            if (CbScanMethod.SelectedIndex < 0)
                return GetScanArgsResult.NO_SCAN_METHOD;

            // Try to get variables
            try
            {
                type = (ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin;
                method = (ISearchMethod)(CbScanMethod.SelectedItem as CBItem).Plugin;
                start = Convert.ToUInt64(TbStartAddress.Text, 16);
                stop = Convert.ToUInt64(TbStopAddress.Text, 16);
            }
            catch { return GetScanArgsResult.INVALID_ADDRESS_RANGE; }

            if (start >= stop)
                return GetScanArgsResult.INVALID_ADDRESS_RANGE;

            param = new object[method.Params.Length];

            // Try to get search params from Type Editor controls
            i = 0;
            foreach (Control ctrl in SplitContainer2.Panel2.Controls)
            {
                if (!(ctrl is MetroFramework.Controls.MetroLabel) && ctrl.Name != null && ctrl.Name != "")
                {
                    sParam = method.Params.Where(x => x.name == ctrl.Name).FirstOrDefault();
                    
                    if (sParam.process) // Convert to byte array
                    {
                        editor = _host.TypeEditors.Where(x => x.EditorType == ((ISearchType)(CbScanDataType.SelectedItem as CBItem).Plugin).ParamType).FirstOrDefault();
                        if (!editor.ProcessParam((UserControl)ctrl, out var ba))
                            return GetScanArgsResult.INVALID_PARAMETER;
                        
                        param[i++] = ba;
                    }
                    else
                    {
                        editor = _host.TypeEditors.Where(x => x.EditorType == sParam.type).FirstOrDefault();
                        editor.GetUnprocessedParam((UserControl)ctrl, out object obj);
                        param[i++] = obj;
                    }
                }
            }

            return GetScanArgsResult.SUCCESS;
        }

        // Populate parameters panel with the required UserControls
        private void UpdateParameters(ISearchMethod method, ISearchType type)
        {
            UserControl ctrl;
            MetroFramework.Controls.MetroLabel label;
            Point initPoint = new Point(12, 4);

            SplitContainer2.Panel2.SuspendLayout();
            SplitContainer2.Panel2.Enabled = false;
            SplitContainer2.Panel2.Controls.Clear();

            if (method.Params != null)
            {
                foreach (Types.SearchParam param in method.Params)
                {
                    // Get the UserControl
                    if (param.process)
                        ctrl = GetTypeEditor(param.name, type.ParamType);
                    else
                        ctrl = GetTypeEditor(param.name, param.type);

                    if (ctrl == null)
                    {
                        MessageBox.Show("Failed to create UserControl type editor for parameter " + param.name + " of type " + (param.process ? type.ParamType : param.type));
                        continue;
                    }

                    label = new MetroFramework.Controls.MetroLabel()
                    {
                        Theme = MetroFramework.MetroThemeStyle.Light,
                        UseCustomBackColor = true,
                        BackColor = Color.Transparent,
                        Text = param.name,
                        Location = new Point(initPoint.X, initPoint.Y),
                        Tag = ctrl
                    };
                    label.Top += (ctrl.Height - label.Height) / 2;
                    MetroToolTip1.SetToolTip(label, param.description);

                    ctrl.Name = param.name;
                    ctrl.Location = new Point(initPoint.X + label.Width + 5, initPoint.Y);
                    ctrl.Width = SplitContainer2.Panel2.Width - ctrl.Left - 4;

                    initPoint.Y += ctrl.Height + 6;

                    SplitContainer2.Panel2.Controls.Add(label);
                    SplitContainer2.Panel2.Controls.Add(ctrl);
                }
            }


            // Adjust controls
            SplitContainer1.SplitterDistance = 110 + initPoint.Y + 5;
            SplitContainer2.SplitterDistance = 110;

            SplitContainer2.Panel2.Enabled = true;
            SplitContainer2.Panel2.ResumeLayout(true);
        }

        // Get Type Editor UserControl from the parameter name and type
        private UserControl GetTypeEditor(string parameterName, Type t)
        {
            // Search the existing type editor user controls
            if (_typeEditorControls.Keys.Contains(parameterName + t.ToString()))
                return _typeEditorControls[parameterName + t.ToString()];

            // Search for the ITypeEditor with EditorType t
            ITypeEditor editor = _host.TypeEditors.Where(x => x.EditorType == t).FirstOrDefault();
            if (editor == null) // None found
            {
                _host.LogText(_searchUIAddOn, "Unable to locate ITypeEditor with EditorType of " + t.ToString());
                return null;
            }

            editor.GetControl(out var ctrl);

            if (ctrl == null)
            {
                _host.LogText(_searchUIAddOn, "ITypeEditor " + editor.GetType().ToString() + " failed to initialize UserControl");
                return null;
            }

            _typeEditorControls.Add(parameterName + t.ToString(), ctrl);
            return ctrl;
        }

        // Add all compatible ISearchTypes to combobox list
        private void UpdateSearchTypes(ISearchMethod method)
        {
            CBItem oldItem = CbScanDataType.SelectedIndex < 0 ? null : (CBItem)CbScanDataType.SelectedItem;
            CBItem item;

            CbScanDataType.BeginUpdate();
            CbScanDataType.SuspendLayout();
            CbScanDataType.Items.Clear();

            for (int x = 0; x < _host.SearchTypes.Count; x++)
            {
                if (method.SupportSearchType(_host.SearchTypes[x]))
                {
                    item = new CBItem(_host.SearchTypes[x]);
                    CbScanDataType.Items.Add(item);
                    if (!_cbScanDataTypeToolTips.Keys.Contains(_host.SearchTypes[x]))
                        _cbScanDataTypeToolTips.Add(_host.SearchTypes[x], item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                        CbScanDataType.SelectedIndex = CbScanDataType.Items.Count - 1;
                }
            }

            CbScanDataType.ResumeLayout(true);
            CbScanDataType.EndUpdate();
        }

        private void UpdateSearchMethods(ISearchType type)
        {
            CBItem oldItem = CbScanMethod.SelectedIndex < 0 ? null : (CBItem)CbScanMethod.SelectedItem;
            CBItem item;

            CbScanMethod.BeginUpdate();
            CbScanMethod.SuspendLayout();
            CbScanMethod.Items.Clear();

            for (int x = 0; x < _host.SearchMethods.Count; x++)
            {
                if (_host.SearchMethods[x].SupportSearchType(type) &&
                    (_host.SearchMethods[x].Mode == Types.SearchMode.Both ||
                    (_host.SearchMethods[x].Mode == Types.SearchMode.First && _isFirstScan) ||
                    (_host.SearchMethods[x].Mode == Types.SearchMode.Next && !_isFirstScan)))
                {
                    item = new CBItem(_host.SearchMethods[x]);
                    CbScanMethod.Items.Add(item);
                    if (!_cbScanMethodToolTips.Keys.Contains(_host.SearchMethods[x]))
                        _cbScanMethodToolTips.Add(_host.SearchMethods[x], item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                        CbScanMethod.SelectedIndex = CbScanMethod.Items.Count - 1;
                }
            }

            CbScanMethod.ResumeLayout(true);
            CbScanMethod.EndUpdate();
        }

        private void UpdateSearchMethods(Types.SearchMode mode)
        {
            CBItem oldItem = CbScanMethod.SelectedIndex < 0 ? null : (CBItem)CbScanMethod.SelectedItem;
            CBItem item;

            CbScanMethod.BeginUpdate();
            CbScanMethod.SuspendLayout();
            CbScanMethod.Items.Clear();
            _isUserInput = false;

            // Setup method combo boxes
            foreach (ISearchMethod sm in _host.SearchMethods)
            {
                if (sm.Mode == mode || sm.Mode == Types.SearchMode.Both)
                {
                    item = new UI.CBItem(sm);
                    this.CbScanMethod.Items.Add(item);
                    if (!_cbScanMethodToolTips.Keys.Contains(sm))
                        _cbScanMethodToolTips.Add(sm, item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                    {
                        CbScanMethod.SelectedIndex = CbScanMethod.Items.Count - 1;

                        // Update Search Data Types
                        UpdateSearchTypes(sm);
                    }
                }
            }

            _isUserInput = true;
            CbScanMethod.ResumeLayout(true);
            CbScanMethod.EndUpdate();
        }

        #endregion

    }

    class CBItem
    {
        public IPluginBase Plugin;

        public CBItem(IPluginBase plugin)
        {
            Plugin = plugin;
        }

        public override string ToString()
        {
            return Plugin.Name + " (" + Plugin.Version.ToString() + ")";
        }

        public string ToTooltip()
        {
            if (Plugin is ISearchMethod)
            {
                return (Plugin as ISearchMethod).Name + " " + (Plugin as ISearchMethod).Version + " by " + (Plugin as ISearchMethod).Author +
                    "\r\n Scan Mode: " + (Plugin as ISearchMethod).Mode + "  Platforms: " + ((Plugin as ISearchMethod).SupportedPlatforms == null ? "All" : String.Join(",", (Plugin as ISearchMethod).SupportedPlatforms)) +
                    "\r\n   " + (Plugin as ISearchMethod).Description + "   ";
            }
            else if (Plugin is ISearchType)
            {
                return (Plugin as ISearchType).Name + " " + (Plugin as ISearchType).Version + " by " + (Plugin as ISearchType).Author +
                    "\r\n Scan Alignment: " + (Plugin as ISearchType).Alignment.ToString() + "  Signed: " + (Plugin as ISearchType).Signed.ToString() +
                    "\r\n C# Data Type: " + (Plugin as ISearchType).ParamType.ToString() + "  Platforms: " + ((Plugin as ISearchType).SupportedPlatforms == null ? "All" : String.Join(",", (Plugin as ISearchType).SupportedPlatforms)) +
                    "\r\n   " + (Plugin as ISearchType).Description + "   ";
            }

            return "";
        }
    }
}
