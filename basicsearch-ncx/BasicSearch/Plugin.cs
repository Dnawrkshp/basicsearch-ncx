using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core;
using NetCheatX.Core.Interfaces;

namespace BasicSearch
{
    public class Plugin : IPluginBase
    {
        // Search methods
        SearchMethod.EqualTo _equalTo = new SearchMethod.EqualTo();
        SearchMethod.NotEqualTo _notEqualTo = new SearchMethod.NotEqualTo();
        SearchMethod.GreaterThan _greaterThan = new SearchMethod.GreaterThan();
        SearchMethod.GreaterThanOrEqualTo _greaterThanOrEqual = new SearchMethod.GreaterThanOrEqualTo();
        SearchMethod.LessThan _lessThan = new SearchMethod.LessThan();
        SearchMethod.LessThanOrEqualTo _lessThanOrEqual = new SearchMethod.LessThanOrEqualTo();
        SearchMethod.ValueBetween _valueBetween = new SearchMethod.ValueBetween();

        // Search types
        SearchType.OneByteS _oneByteS = new SearchType.OneByteS();
        SearchType.OneByteU _oneByteU = new SearchType.OneByteU();
        SearchType.TwoByteS _twoByteS = new SearchType.TwoByteS();
        SearchType.TwoByteU _twoByteU = new SearchType.TwoByteU();
        SearchType.FourByteS _fourByteS = new SearchType.FourByteS();
        SearchType.FourByteU _fourByteU = new SearchType.FourByteU();
        SearchType.EightByteS _eightByteS = new SearchType.EightByteS();
        SearchType.EightByteU _eightByteU = new SearchType.EightByteU();
        SearchType.XByteS _xByteS = new SearchType.XByteS();
        SearchType.XByteU _xByteU = new SearchType.XByteU();
        SearchType.SingleFP _singleFP = new SearchType.SingleFP();
        SearchType.DoubleFP _doubleFP = new SearchType.DoubleFP();
        SearchType.Text _text = new SearchType.Text();

        // Type editors
        SearchParamEditor.typeSByte _teSByte = new SearchParamEditor.typeSByte();
        SearchParamEditor.typeByte _teByte = new SearchParamEditor.typeByte();
        SearchParamEditor.typeShort _teShort = new SearchParamEditor.typeShort();
        SearchParamEditor.typeUShort _teUShort = new SearchParamEditor.typeUShort();
        SearchParamEditor.typeInt _teInt = new SearchParamEditor.typeInt();
        SearchParamEditor.typeUInt _teUInt = new SearchParamEditor.typeUInt();
        SearchParamEditor.typeLong _teLong = new SearchParamEditor.typeLong();
        SearchParamEditor.typeULong _teULong = new SearchParamEditor.typeULong();
        SearchParamEditor.typeFloat _teFloat = new SearchParamEditor.typeFloat();
        SearchParamEditor.typeDouble _teDouble = new SearchParamEditor.typeDouble();
        SearchParamEditor.typeString _teString = new SearchParamEditor.typeString();
        SearchParamEditor.typeByteArray _teByteArray = new SearchParamEditor.typeByteArray();
        SearchParamEditor.typeSByteArray _teSByteArray = new SearchParamEditor.typeSByteArray();

        // Add ons
        AddOn.SearchUIAddOn _searchUI = new AddOn.SearchUIAddOn();


        private ObjectVersion _version = null;
        public string Author { get; } = "Daniel Gerendasy";
        public string Description { get; } = "Plugin containing basic search methods, data types, and data type editors for NetCheat X.";
        public string Name { get; } = "BasicSearch";
        public ObjectVersion Version { get { return _version; } }

        public void Initialize(IPluginHost host)
        {
            _version = new ObjectVersion(1, 0);

            // Register Search Methods
            host.SearchMethods.Add(this, _equalTo);
            host.SearchMethods.Add(this, _notEqualTo);
            host.SearchMethods.Add(this, _greaterThan);
            host.SearchMethods.Add(this, _greaterThanOrEqual);
            host.SearchMethods.Add(this, _lessThan);
            host.SearchMethods.Add(this, _lessThanOrEqual);
            host.SearchMethods.Add(this, _valueBetween);

            // Register Search Types
            host.SearchTypes.Add(this, _oneByteS);
            host.SearchTypes.Add(this, _oneByteU);
            host.SearchTypes.Add(this, _twoByteS);
            host.SearchTypes.Add(this, _twoByteU);
            host.SearchTypes.Add(this, _fourByteS);
            host.SearchTypes.Add(this, _fourByteU);
            host.SearchTypes.Add(this, _eightByteS);
            host.SearchTypes.Add(this, _eightByteU);
            host.SearchTypes.Add(this, _xByteS);
            host.SearchTypes.Add(this, _xByteU);
            host.SearchTypes.Add(this, _singleFP);
            host.SearchTypes.Add(this, _doubleFP);
            host.SearchTypes.Add(this, _text);

            // Register Type Editors
            host.TypeEditors.Add(this, _teSByte);
            host.TypeEditors.Add(this, _teByte);
            host.TypeEditors.Add(this, _teShort);
            host.TypeEditors.Add(this, _teUShort);
            host.TypeEditors.Add(this, _teInt);
            host.TypeEditors.Add(this, _teUInt);
            host.TypeEditors.Add(this, _teLong);
            host.TypeEditors.Add(this, _teULong);
            host.TypeEditors.Add(this, _teFloat);
            host.TypeEditors.Add(this, _teDouble);
            host.TypeEditors.Add(this, _teString);
            host.TypeEditors.Add(this, _teByteArray);
            host.TypeEditors.Add(this, _teSByteArray);

            // Register Add Ons
            host.AddOns.Add(this, _searchUI);
        }

        public void Dispose(IPluginHost host)
        {
            // Clean up
            _equalTo = null;
            _notEqualTo = null;
            _greaterThan = null;
            _greaterThanOrEqual = null;
            _lessThan = null;
            _lessThanOrEqual = null;
            _valueBetween = null;

            _oneByteS = null;
            _oneByteU = null;
            _twoByteS = null;
            _twoByteU = null;
            _fourByteS = null;
            _fourByteU = null;
            _eightByteS = null;
            _eightByteU = null;
            _xByteS = null;
            _xByteU = null;
            _singleFP = null;
            _doubleFP = null;
            _text = null;

            _teSByte = null;
            _teByte = null;
            _teShort = null;
            _teUShort = null;
            _teInt = null;
            _teUInt = null;
            _teLong = null;
            _teULong = null;
            _teFloat = null;
            _teDouble = null;
            _teString = null;
            _teByteArray = null;
            _teSByteArray = null;

            _searchUI = null;

            _version = null;
        }
    }
}
