using Aspose.ThreeD;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace ConvertObjToFbxAndColorate
{
    public class Converter
    {
        public static Color HexToColor(string hexString)
        {
            //replace # occurences
            if( hexString.IndexOf('#') != -1 )
                hexString = hexString.Replace("#", "");

            int r,g,b = 0;

            r = int.Parse(hexString.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            g = int.Parse(hexString.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            b = int.Parse(hexString.Substring(4, 2), NumberStyles.AllowHexSpecifier);

            return Color.FromArgb(r, g, b);
        }
        public static void ConverteFromObjToFbx(IEnumerable<ThreeDModelRepresenter> modelsCollection, string to)
        {
            var mainDocument = new Scene();
            
            foreach(var model in modelsCollection )
            {
                var document = new Scene(model.PathToModel);
                PhongMaterial mat = new PhongMaterial();

                Color color = HexToColor(model.ColorHexFromat);
                mat.AmbientColor = new Vector3(color);
                mat.DiffuseColor = new Vector3(color);
                mat.EmissiveColor = new Vector3(color);
                mat.TransparentColor = new Vector3(color);
                document.RootNode.ChildNodes[0].Material = mat;

                mainDocument.RootNode.AddChildNode(document.RootNode);

            }
            var options = new FBXSaveOptions(FileFormat.FBX7500Binary);
            mainDocument.Save(to, options);
        }
    }
}
