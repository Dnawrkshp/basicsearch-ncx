﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;

namespace BasicSearch.SearchParamEditor
{
    public class typeFloat : ITypeEditor
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Edits data type Float.";

        public string Name { get; } = "Float Editor";

        public ObjectVersion Version { get { return _version; } }

        // Data type
        public Type EditorType { get; } = typeof(float);


        public void GetControl(out System.Windows.Forms.UserControl control)
        {
            // Return initialize editor control
            control = new UI.floatControl();
        }

        public void SetParam(System.Windows.Forms.UserControl control, byte[] param)
        {
            // Make sure control is valid
            if (control is UI.floatControl)
                (control as UI.floatControl).Value = _host.ActiveCommunicator.PlatformBitConverter.ToSingle(param, 0);
        }

        public bool ProcessParam(System.Windows.Forms.UserControl control, out byte[] param)
        {
            param = null;

            // Make sure control is of proper type
            if (control is UI.floatControl)
                return false;

            param = _host.ActiveCommunicator.PlatformBitConverter.GetBytes((control as UI.floatControl).Value);
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
