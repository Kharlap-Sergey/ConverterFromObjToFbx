using System.Drawing;
using System.Globalization;

namespace Solver
{
    public static class ColorConverter
    {
        /// <summary>
        /// convert hex color string to Color class 
        /// </summary>
        /// <param name="hexString">hex color representer</param>
        /// <returns></returns>
        public static Color HexToColor(string hexString)
        {
            //replace # occurrences
            if( hexString.IndexOf('#') != -1 )
                hexString = hexString.Replace("#", "");

            int r,g,b = 0;

            r = int.Parse(
                hexString.Substring(0, 2), 
                NumberStyles.AllowHexSpecifier
                );
            g = int.Parse(
                hexString.Substring(2, 2), 
                NumberStyles.AllowHexSpecifier
                );
            b = int.Parse(
                hexString.Substring(4, 2), 
                NumberStyles.AllowHexSpecifier);

            return Color.FromArgb(r, g, b);
        }
    }
}
