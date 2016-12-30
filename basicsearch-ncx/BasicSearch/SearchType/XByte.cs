using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace BasicSearch.SearchType
{
    public class XByteS : ISearchType
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "X signed bytes. Number of bytes determined by number of input bytes";

        public string Name { get; } = "X Byte Signed";

        public ObjectVersion Version { get { return _version; } }

        public bool Signed { get; } = true;

        public int Alignment { get; } = 1;

        // Columns
        public string[] Columns { get; } = new string[] { "Address", "Hex" };

        // Input type
        public Type ParamType { get; } = typeof(sbyte[]);

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        public void ProcessResult(out string[] columnValues, ISearchResult result)
        {
            columnValues = new string[2];

            columnValues[0] = result.Address.ToString("X16");
            columnValues[1] = BitConverter.ToString(result.Value).Replace("-", "");
        }

        public void ResultToLegacyCode(out string code, ISearchResult result)
        {
            code = "0 " + result.Address.ToString("X" + (result.Address > uint.MaxValue ? "16" : "8")) + " " + _host.ActiveCommunicator.PlatformBitConverter.ToString(result.Value).Replace("-", "");
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

    public class XByteU : ISearchType
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "X unsigned bytes. Number of bytes determined by number of input bytes";

        public string Name { get; } = "X Byte Unsigned";

        public ObjectVersion Version { get { return _version; } }

        public bool Signed { get; } = false;

        public int Alignment { get; } = 1;

        // Columns
        public string[] Columns { get; } = new string[] { "Address", "Hex" };

        // Input type
        public Type ParamType { get; } = typeof(byte[]);

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        public void ProcessResult(out string[] columnValues, ISearchResult result)
        {
            columnValues = new string[2];

            columnValues[0] = result.Address.ToString("X16");
            columnValues[1] = BitConverter.ToString(result.Value).Replace("-", "");
        }

        public void ResultToLegacyCode(out string code, ISearchResult result)
        {
            code = "0 " + result.Address.ToString("X" + (result.Address > uint.MaxValue ? "16" : "8")) + " " + _host.ActiveCommunicator.PlatformBitConverter.ToString(result.Value).Replace("-", "");
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
