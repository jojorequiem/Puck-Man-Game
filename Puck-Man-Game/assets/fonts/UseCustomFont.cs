using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Puck_Man_Game.assets.fonts
{
    internal class UseCustomFont
    {
        public static void ApplyCustomFont(string fontFilePath, int fontSize, Control control)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(fontFilePath);
            Font customFont = new Font(fontCollection.Families[0], fontSize);

            // Appliquer la police au contrôle spécifié
            control.Font = customFont;
        }

        /*   public static void ApplyCustomFont(int fontSize, Control control)
           {
               byte[] fontData = Properties.Resources.fonts_pixel_art;
               PrivateFontCollection pfc = new PrivateFontCollection();
               IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
               Marshal.Copy(fontData, 0, data, fontData.Length);
               pfc.AddMemoryFont(data, fontData.Length);
               Marshal.FreeCoTaskMem(data);
               Font customFont = new Font(pfc.Families[0], fontSize);
               control.Font = customFont;
           }*/
    }
}

