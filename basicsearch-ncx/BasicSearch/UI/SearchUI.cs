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

namespace BasicSearch.UI
{
    public partial class SearchUI : NetCheatX.Core.UI.XForm
    {
        private bool _isUserInput = true;

        private AddOn.SearchUIAddOn _searchUIAddOn = null;
        private IPluginHost _host = null;
        private ResultContainer<NetCheatX.Core.Interfaces.ISearchResult> _searchResults = new ResultContainer<NetCheatX.Core.Interfaces.ISearchResult>();
        private bool _isFirstScan = true;

        // Tooltip text for each ISearchMethod and ISearchType
        private Dictionary<ISearchMethod, string> _cbScanMethodToolTips = new Dictionary<ISearchMethod, string>();
        private Dictionary<ISearchType, string> _cbScanDataTypeToolTips = new Dictionary<ISearchType, string>();

        private Dictionary<string, UserControl> _typeEditorControls = new Dictionary<string, UserControl>();

        public SearchUI(IPluginHost host, AddOn.SearchUIAddOn searchUIAddOn)
        {
            CBItem item;

            _searchUIAddOn = searchUIAddOn;
            _host = host;

            InitializeComponent();

            cbScanMethod.Items.Clear();
            cbScanDataType.Items.Clear();

            // Setup data type and method combo boxes
            foreach (ISearchMethod sm in host.SearchMethods)
            {
                if (sm.Mode == Types.SearchMode.First || sm.Mode == Types.SearchMode.Both)
                {
                    item = new UI.CBItem(sm);
                    this.cbScanMethod.Items.Add(item);
                    _cbScanMethodToolTips.Add(sm, item.ToTooltip());
                }
            }

            foreach (ISearchType st in host.SearchTypes)
            {
                item = new UI.CBItem(st);
                this.cbScanDataType.Items.Add(item);
                _cbScanDataTypeToolTips.Add(st, item.ToTooltip());
            }
        }

        #region Event Handlers

        private void SearchUI_Resize(object sender, EventArgs e)
        {
            pbScanProgress.Width = this.Width - 202;
        }

        private void cbScanMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(cbScanMethod, "Scan Method.");

            int i = cbScanMethod.SelectedIndex;
            if (i < 0)
                return;

            if (i < _host.SearchMethods.Count)
                metroToolTip1.SetToolTip(cbScanMethod, _cbScanMethodToolTips[(ISearchMethod)(cbScanMethod.SelectedItem as CBItem).Plugin]);

            if (_isUserInput)
            {
                // Update parameters
                if (cbScanDataType.SelectedIndex >= 0)
                    UpdateParameters((ISearchMethod)(cbScanMethod.SelectedItem as CBItem).Plugin, (ISearchType)(cbScanDataType.SelectedItem as CBItem).Plugin);

                _isUserInput = false;
                UpdateSearchTypes((ISearchMethod)(cbScanMethod.SelectedItem as CBItem).Plugin);
                _isUserInput = true;
            }
        }

        private void cbScanDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroToolTip1.SetToolTip(cbScanDataType, "Scan Data Type.");

            int i = cbScanDataType.SelectedIndex;
            if (i < 0)
                return;

            if (i < _host.SearchTypes.Count)
                metroToolTip1.SetToolTip(cbScanDataType, _cbScanDataTypeToolTips[(ISearchType)(cbScanDataType.SelectedItem as CBItem).Plugin]);

            if (_isUserInput)
            {
                // Update parameters
                if (cbScanMethod.SelectedIndex >= 0)
                    UpdateParameters((ISearchMethod)(cbScanMethod.SelectedItem as CBItem).Plugin, (ISearchType)(cbScanDataType.SelectedItem as CBItem).Plugin);

                _isUserInput = false;
                UpdateSearchMethods((ISearchType)(cbScanDataType.SelectedItem as CBItem).Plugin);
                _isUserInput = true;
            }
        }

        private void btBeginScan_Click(object sender, EventArgs e)
        {
            
        }

        private void btStopScan_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Private Functions

        // Populate parameters panel with the required UserControls
        private void UpdateParameters(ISearchMethod method, ISearchType type)
        {
            UserControl ctrl;
            MetroFramework.Controls.MetroLabel label;
            Point initPoint = new Point(12, 4);

            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.Panel2.Enabled = false;
            splitContainer2.Panel2.Controls.Clear();

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
                    metroToolTip1.SetToolTip(label, param.description);

                    ctrl.Location = new Point(initPoint.X + label.Width + 5, initPoint.Y);
                    ctrl.Width = splitContainer2.Panel2.Width - ctrl.Left - 4;

                    initPoint.Y += ctrl.Height + 6;

                    splitContainer2.Panel2.Controls.Add(label);
                    splitContainer2.Panel2.Controls.Add(ctrl);
                }
            }


            // Adjust controls
            splitContainer1.SplitterDistance = 110 + initPoint.Y + 5;
            splitContainer2.SplitterDistance = 110;

            splitContainer2.Panel2.Enabled = true;
            splitContainer2.Panel2.ResumeLayout(true);
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

            UserControl ctrl;
            editor.GetControl(out ctrl);

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
            CBItem oldItem = cbScanDataType.SelectedIndex < 0 ? null : (CBItem)cbScanDataType.SelectedItem;
            CBItem item;

            cbScanDataType.BeginUpdate();
            cbScanDataType.SuspendLayout();
            cbScanDataType.Items.Clear();

            for (int x = 0; x < _host.SearchTypes.Count; x++)
            {
                if (method.SupportSearchType(_host.SearchTypes[x]))
                {
                    item = new CBItem(_host.SearchTypes[x]);
                    cbScanDataType.Items.Add(item);
                    if (!_cbScanDataTypeToolTips.Keys.Contains(_host.SearchTypes[x]))
                        _cbScanDataTypeToolTips.Add(_host.SearchTypes[x], item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                        cbScanDataType.SelectedIndex = cbScanDataType.Items.Count - 1;
                }
            }

            cbScanDataType.ResumeLayout(true);
            cbScanDataType.EndUpdate();
        }

        private void UpdateSearchMethods(ISearchType type)
        {
            CBItem oldItem = cbScanMethod.SelectedIndex < 0 ? null : (CBItem)cbScanMethod.SelectedItem;
            CBItem item;

            cbScanMethod.BeginUpdate();
            cbScanMethod.SuspendLayout();
            cbScanMethod.Items.Clear();

            for (int x = 0; x < _host.SearchMethods.Count; x++)
            {
                if (_host.SearchMethods[x].SupportSearchType(type) &&
                    (_host.SearchMethods[x].Mode == Types.SearchMode.Both ||
                    (_host.SearchMethods[x].Mode == Types.SearchMode.First && _isFirstScan) ||
                    (_host.SearchMethods[x].Mode == Types.SearchMode.Next && !_isFirstScan)))
                {
                    item = new CBItem(_host.SearchMethods[x]);
                    cbScanMethod.Items.Add(item);
                    if (!_cbScanMethodToolTips.Keys.Contains(_host.SearchMethods[x]))
                        _cbScanMethodToolTips.Add(_host.SearchMethods[x], item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                        cbScanMethod.SelectedIndex = cbScanMethod.Items.Count - 1;
                }
            }

            cbScanMethod.ResumeLayout(true);
            cbScanMethod.EndUpdate();
        }

        private void UpdateSearchMethods(Types.SearchMode mode)
        {
            CBItem oldItem = cbScanMethod.SelectedIndex < 0 ? null : (CBItem)cbScanMethod.SelectedItem;
            CBItem item;

            cbScanMethod.BeginUpdate();
            cbScanMethod.SuspendLayout();
            cbScanMethod.Items.Clear();
            _isUserInput = false;

            // Setup method combo boxes
            foreach (ISearchMethod sm in _host.SearchMethods)
            {
                if (sm.Mode == mode || sm.Mode == Types.SearchMode.Both)
                {
                    item = new UI.CBItem(sm);
                    this.cbScanMethod.Items.Add(item);
                    if (!_cbScanMethodToolTips.Keys.Contains(sm))
                        _cbScanMethodToolTips.Add(sm, item.ToTooltip());

                    if (oldItem != null && oldItem.Plugin == item.Plugin)
                    {
                        cbScanMethod.SelectedIndex = cbScanMethod.Items.Count - 1;

                        // Update Search Data Types
                        UpdateSearchTypes(sm);
                    }
                }
            }

            _isUserInput = true;
            cbScanMethod.ResumeLayout(true);
            cbScanMethod.EndUpdate();
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
