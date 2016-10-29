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
    public class typeSByte : ITypeEditor
    {
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Edits data type SByte.";

        public string Name { get; } = "SByte Editor";

        public ObjectVersion Version { get { return _version; } }

        // Data type
        public Type EditorType { get; } = typeof(sbyte);


        public void GetControl(out System.Windows.Forms.UserControl control)
        {
            // Return initialize editor control
            control = new UI.sbyteControl();
        }

        public void SetParam(System.Windows.Forms.UserControl control, byte[] param)
        {
            // Make sure control is valid
            if (control is UI.sbyteControl)
                (control as UI.sbyteControl).Value = (sbyte)param[0];
        }

        public bool ProcessParam(System.Windows.Forms.UserControl control, out byte[] param)
        {
            param = null;

            // Make sure control is of proper type
            if (control is UI.sbyteControl)
                return false;

            param = new byte[] { (byte)(control as UI.sbyteControl).Value };
            return true;
        }


        public void Initialize(IPluginHost host)
        {
            _version = new ObjectVersion(1, 0);
        }

        public void Dispose(IPluginHost host)
        {
            // Clean up
            _version = null;
        }
    }
}
