using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace BasicSearch.SearchType
{
    public class TwoByteS : ISearchType
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "2 signed bytes. -32768 to 32767.";

        public string Name { get; } = "Int16";

        public ObjectVersion Version { get { return _version; } }

        public bool Signed { get; } = true;

        public int Alignment { get; } = 2;

        // Columns
        public string[] Columns { get; } = new string[] { "Address", "Hex", "Decimal" };

        // Input type
        public Type ParamType { get; } = typeof(short);

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        public void ProcessResult(out string[] columnValues, ISearchResult result)
        {
            columnValues = new string[3];

            columnValues[0] = result.Address.ToString("X16");
            columnValues[1] = _host.ActiveCommunicator.PlatformBitConverter.ToString(result.Value).Replace("-", "");
            columnValues[2] = _host.ActiveCommunicator.PlatformBitConverter.ToInt16(result.Value, 0).ToString();
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

    public class TwoByteU : ISearchType
    {
        private IPluginHost _host = null;
        private ObjectVersion _version = null;


        public string Author { get; } = "Daniel Gerendasy";

        public string Description { get; } = "2 unsigned bytes. 0 to 65535.";

        public string Name { get; } = "UInt16";

        public ObjectVersion Version { get { return _version; } }

        public bool Signed { get; } = false;

        public int Alignment { get; } = 2;

        // Columns
        public string[] Columns { get; } = new string[] { "Address", "Hex", "Decimal" };

        // Input type
        public Type ParamType { get; } = typeof(ushort);

        // Support all platforms
        public string[] SupportedPlatforms { get; } = null;

        public void ProcessResult(out string[] columnValues, ISearchResult result)
        {
            columnValues = new string[3];

            columnValues[0] = result.Address.ToString("X16");
            columnValues[1] = _host.ActiveCommunicator.PlatformBitConverter.ToString(result.Value).Replace("-", "");
            columnValues[2] = _host.ActiveCommunicator.PlatformBitConverter.ToUInt16(result.Value, 0).ToString();
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
