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
    public class typeByteArray : ITypeEditor
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Edits data type Byte[].";

        public string Name { get; } = "Byte[] Editor";

        public ObjectVersion Version { get { return _version; } }

        // Data type
        public Type EditorType { get; } = typeof(byte[]);


        public void GetControl(out System.Windows.Forms.UserControl control)
        {
            // Return initialize editor control
            control = new UI.byteArrayControl();
        }

        public void SetParam(System.Windows.Forms.UserControl control, byte[] param)
        {
            // Make sure control is valid
            if (control is UI.byteArrayControl)
                (control as UI.byteArrayControl).Value = _host.ActiveCommunicator.PlatformBitConverter.ToString(param).Replace("-", "");
        }

        public bool ProcessParam(System.Windows.Forms.UserControl control, out byte[] param)
        {
            param = null;

            // Make sure control is of proper type
            if (!(control is UI.byteArrayControl))
                return false;

            param = (BitConverter.IsLittleEndian ? NetCheatX.Core.Bitlogic.EndianBitConverter.LittleEndianBitConverter : NetCheatX.Core.Bitlogic.EndianBitConverter.BigEndianBitConverter).GetBytes((control as UI.byteArrayControl).Value);
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
