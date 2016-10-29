using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.UI;
using NetCheatX.Core.Interfaces;

namespace BasicSearch.AddOn
{
    public class SearchUIAddOn : IAddOn
    {
        private string searchui_form_id = "BASICSEARCHUI";

        private IPluginHost _host = null;

        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Basic search UI for NetCheatX.";

        public string Name { get; } = "BasicSearch UI";

        public ObjectVersion Version { get { return _version; } }

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        // Add SearchUI when menustrip item clicked
        public bool AddXFormCallback(out NetCheatX.Core.UI.XForm xForm, IPluginHost host)
        {
            xForm = null;
            if (host == null)
                return false;

            xForm = new UI.SearchUI(host, this);
            return true;
        }

        // Initialize SearchUI from uniqueName
        public bool InitializeXForm(out XForm xForm, string uniqueName)
        {
            xForm = null;
            if (_host == null)
                return false;

            if (uniqueName == searchui_form_id)
                xForm = new UI.SearchUI(_host, this);

            if (xForm != null)
                return true;
            return false;
        }

        public void Initialize(IPluginHost host)
        {
            _host = host;

            searchui_form_id = Name + " " + Version + " " + searchui_form_id;
            _version = new ObjectVersion(1, 0);

            host.RegisterWindow(this, "Scan/Basic Scanner", searchui_form_id, Description, AddXFormCallback);
        }

        public void Dispose(IPluginHost host)
        {
            
        }
    }
}
