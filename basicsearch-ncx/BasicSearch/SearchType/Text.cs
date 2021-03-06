﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace BasicSearch.SearchType
{
    public class Text : ISearchType
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "Text string.";

        public string Name { get; } = "Text";

        public ObjectVersion Version { get { return _version; } }

        public bool Signed { get; } = false;

        public int Alignment { get; } = 1;

        // Columns
        public string[] Columns { get; } = new string[] { "Address", "Text" };

        // Input type
        public Type ParamType { get; } = typeof(string);

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        public void ProcessResult(out string[] columnValues, ISearchResult result)
        {
            columnValues = new string[2];

            columnValues[0] = result.Address.ToString("X16");
            columnValues[1] = Encoding.UTF8.GetString(result.Value);
        }

        public void ResultToLegacyCode(out string code, ISearchResult result)
        {
            code = "1 " + result.Address.ToString("X" + (result.Address > uint.MaxValue ? "16" : "8")) + " " + Encoding.UTF8.GetString(result.Value);
        }

        public void Initialize(IPluginHost host)
        {
            _host = host;
            _version = new ObjectVersion(1, 0);
        }

        public void Dispose(IPluginHost host)
        {
            _host = null;
        }
    }
}
