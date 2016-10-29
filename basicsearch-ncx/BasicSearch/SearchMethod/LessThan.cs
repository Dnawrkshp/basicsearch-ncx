using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;

namespace BasicSearch.SearchMethod
{
    class LessThan : ISearchMethod
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;

        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "If values within memory range are less than parameter0.";

        public string Name { get; } = "Less Than";

        public ObjectVersion Version { get { return _version; } }

        public Types.SearchMode Mode { get; } = Types.SearchMode.Both;

        public Types.SearchParam[] Params { get; } = new Types.SearchParam[] {
            // Set process to true so the ISearchType processes the input into a byte array
            // Set type to null for good measure
            new Types.SearchParam() { name = "parameter0", process = true, type = null, description = "Value to compare memory to." }
        };

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;


        public void FirstScan(out List<ISearchResult> result, ISearchType searchType, object[] args, Types.MemoryRange[] range, Types.SetProgressCallback setProgress)
        {
            // Initialize list
            result = new List<ISearchResult>();
            if (_host == null)
                return;

            // Grab parameters
            byte[] param0 = (byte[])args[0];

            // Loop through each range and scan
            foreach (Types.MemoryRange r in range)
            {
                Search.FirstScan(_host, this, setProgress, r, ref result, Search.SearchType.LessThan, searchType.Signed, searchType.Alignment, param0);
            }
        }

        public void NextScan(ref List<ISearchResult> result, ISearchType searchType, object[] args, Types.SetProgressCallback setProgress)
        {
            if (_host == null)
                return;

            // Grab parameters
            byte[] param0 = (byte[])args[0];
            bool sign = (bool)args[1];

            // Perform scan
            Search.NextScan(_host, this, setProgress, ref result, Search.SearchType.LessThan, sign, param0);
        }

        public bool SupportSearchType(ISearchType sType)
        {
            // Less Than should support all search types
            return true;
        }

        public void Initialize(IPluginHost host)
        {
            _host = host;
            _version = new ObjectVersion(1, 0);
        }

        public void Dispose(IPluginHost host)
        {
            _host = null;
            _version = null;
        }
    }
}
