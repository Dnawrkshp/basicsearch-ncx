using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicSearch.UI.Fonts
{
    public static class UbuntuMono
    {
        private static PrivateFontCollection _privateFontCollection = new PrivateFontCollection();
        private static bool _setup = false;

        private static Font _ubuntuMonoRegular = null;

        public static Font UbuntuMonoRegular
        {
            get
            {
                if (!_setup)
                    Setup();
                return _ubuntuMonoRegular;
            }
        }

        private static void Setup()
        {
            AddFont(Properties.Resources.UbuntuMono_R);

            _ubuntuMonoRegular = new Font(GetFontFamilyByName("Ubuntu Mono"), 8.75f, FontStyle.Regular);

            _setup = true;
        }

        private static FontFamily GetFontFamilyByName(string name)
        {
            return _privateFontCollection.Families.FirstOrDefault(x => x.Name == name);
        }

        private static void AddFont(byte[] fontBytes)
        {
            // allocate memory and copy byte[] to the location
            IntPtr data = Marshal.AllocCoTaskMem(fontBytes.Length);
            Marshal.Copy(fontBytes, 0, data, fontBytes.Length);

            // pass the font to the font collection
            _privateFontCollection.AddMemoryFont(data, fontBytes.Length);

            // Free the unsafe memory
            Marshal.FreeCoTaskMem(data);
        }
    }
}
