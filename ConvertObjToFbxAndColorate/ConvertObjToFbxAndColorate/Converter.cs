using Aspose.ThreeD;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using System.Collections.Generic;
using System.Drawing;

namespace ConvertObjToFbxAndColorate
{
    public static class Converter
    {
        public static void ConverteFromObjToFbx(
            IEnumerable<ThreeDModelRepresenter> modelsCollection, 
            string to
            )
        {
            var mainDocument = new Scene();
            
            foreach(var model in modelsCollection )
            {
                var document = new Scene(model.PathToModel);
                PhongMaterial mat = new PhongMaterial();

                Color color = ColorConverter.HexToColor(model.ColorHexFromat);
                mat.AmbientColor = new Vector3(color);
                mat.DiffuseColor = new Vector3(color);
                mat.EmissiveColor = new Vector3(color);
                mat.TransparentColor = new Vector3(color);
                document.RootNode.ChildNodes[0].Material = mat;

                mainDocument.RootNode.AddChildNode(document.RootNode);

            }
            var options = new FbxSaveOptions(FileFormat.FBX7500Binary);
            mainDocument.Save(to, options);
        }
    }
}
