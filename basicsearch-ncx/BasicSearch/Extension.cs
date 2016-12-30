using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetCheatX.Core.Bitlogic;
using NetCheatX.Core;

namespace BasicSearch
{
    public static class Extension
    {
        public static EndianBitConverter GetInverseEndianBitConverter(this EndianBitConverter b)
        {
            return b.Endianness == Types.Endian.BigEndian ? EndianBitConverter.LittleEndianBitConverter : EndianBitConverter.BigEndianBitConverter;
        }
    }
}
