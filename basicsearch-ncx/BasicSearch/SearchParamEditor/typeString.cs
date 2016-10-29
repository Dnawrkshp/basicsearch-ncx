using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace BasicSearch.SearchParamEditor
{
    public class typeString : ITypeEditor
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;

        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Edits data type String.";

        public string Name { get; } = "String Editor";

        public ObjectVersion Version { get { return _version; } }

        // Data type
        public Type EditorType { get; } = typeof(string);


        public void GetControl(out System.Windows.Forms.UserControl control)
        {
            // Return initialize editor control
            control = new UI.stringControl();
        }

        public void SetParam(System.Windows.Forms.UserControl control, byte[] param)
        {
            // Make sure control is valid
            if (control is UI.stringControl)
                (control as UI.stringControl).Value = Encoding.UTF8.GetString(param);
        }

        public bool ProcessParam(System.Windows.Forms.UserControl control, out byte[] param)
        {
            param = null;

            // Make sure control is of proper type
            if (control is UI.stringControl)
                return false;

            param = (control as UI.stringControl).UTF8 ?
                Encoding.UTF8.GetBytes((control as UI.stringControl).Value) :
                Encoding.ASCII.GetBytes((control as UI.stringControl).Value);
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
