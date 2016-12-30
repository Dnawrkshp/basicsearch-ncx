using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;

namespace BasicSearch.SearchParamEditor
{
    public class typeShort : ITypeEditor
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Edits data type Short.";

        public string Name { get; } = "Short Editor";

        public ObjectVersion Version { get { return _version; } }

        // Data type
        public Type EditorType { get; } = typeof(short);


        public void GetControl(out System.Windows.Forms.UserControl control)
        {
            // Return initialize editor control
            control = new UI.shortControl();
        }

        public void GetUnprocessedParam(System.Windows.Forms.UserControl control, out object value)
        {
            value = null;
            if (control != null && control is UI.shortControl)
                value = (control as UI.shortControl).Value;
        }

        public void SetParam(System.Windows.Forms.UserControl control, byte[] param)
        {
            // Make sure control is valid
            if (control is UI.shortControl)
                (control as UI.shortControl).Value = _host.ActiveCommunicator.PlatformBitConverter.ToInt16(param, 0);
        }

        public bool ProcessParam(System.Windows.Forms.UserControl control, out byte[] param)
        {
            param = null;

            // Make sure control is of proper type
            if (!(control is UI.shortControl))
                return false;

            param = _host.ActiveCommunicator.PlatformBitConverter.GetBytes((control as UI.shortControl).Value);
            return true;
        }


        public void Initialize(IPluginHost host)
        {
            _host = host;
            _version = new ObjectVersion(1, 0);
        }

        public void Dispose(IPluginHost host)
        {
            // Clean up
            _host = null;
            _version = null;
        }
    }
}
