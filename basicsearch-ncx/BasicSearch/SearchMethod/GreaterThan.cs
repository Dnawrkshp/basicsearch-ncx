﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;
using NetCheatX.Core.UI;

namespace BasicSearch.SearchMethod
{
    class GreaterThan : ISearchMethod
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;

        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "If values within memory range are greater than parameter0.";

        public string Name { get; } = "Greater Than";

        public ObjectVersion Version { get { return _version; } }

        public Types.SearchMode Mode { get; } = Types.SearchMode.Both;

        public Types.SearchParam[] Params { get; } = new Types.SearchParam[] {
            // Set process to true so the ISearchType processes the input into a byte array
            // Set type to null for good measure
            new Types.SearchParam() { name = "parameter0", process = true, type = null, description = "Value to compare memory to." }
        };

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;


        public void FirstScan(ref NetCheatX.Core.Containers.SearchResultContainer<ISearchResult> result, ISearchType searchType, object[] args, Types.MemoryRange[] range, Types.SetProgressCallback setProgress)
        {
            if (result == null)
                result = new NetCheatX.Core.Containers.SearchResultContainer<ISearchResult>();
            if (_host == null || searchType == null)
                return;

            // Grab parameters
            byte[] param0 = (byte[])args[0];

            // Loop through each range and scan
            foreach (Types.MemoryRange r in range)
            {
                Search.FirstScan(_host, this, setProgress, r, result, Search.SearchType.GreaterThan, searchType.Signed, searchType.Alignment, param0);
            }
        }

        public void NextScan(ref NetCheatX.Core.Containers.SearchResultContainer<ISearchResult> result, ISearchType searchType, object[] args, Types.SetProgressCallback setProgress)
        {
            if (_host == null || result == null || result.Count == 0)
                return;

            // Grab parameters
            byte[] param0 = (byte[])args[0];

            // Perform scan
            Search.NextScan(_host, this, setProgress, result, Search.SearchType.GreaterThan, searchType.Signed, param0);
        }

        public bool SupportSearchType(ISearchType sType)
        {
            // Greater Than should support all search types
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
