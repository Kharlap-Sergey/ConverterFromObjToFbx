using Aspose.ThreeD;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using System.Collections.Generic;
using System.Drawing;

namespace Solver
{
    public static class Converter
    {
        /// <summary>
        /// Merge many .obj files into one .fbx file and colorate each
        /// </summary>
        /// <param name="modelsCollection"></param>
        /// <param name="to">output file path with .fbx format</param>
        public static void MergeAndColorateObjFilesToFbxFile(
            IEnumerable<ThreeDModelRepresenter> modelsCollection, 
            string to
            )
        {
            var mainDocument = new Scene();
            
            foreach(var model in modelsCollection )
            {
                var document = new Scene(model.PathToModel);
                Color color = ColorConverter.HexToColor(model.ColorHexFromat);
                document = ColorateScene(document, color);

                mainDocument.RootNode.AddChildNode(document.RootNode);
            }
            var options = new FbxSaveOptions(FileFormat.FBX7500Binary);
            mainDocument.Save(to, options);
        }

        public static Scene ColorateScene(Scene scene, Color color)
        {
            PhongMaterial mat = new PhongMaterial();

           
            mat.AmbientColor = new Vector3(color);
            mat.DiffuseColor = new Vector3(color);
            mat.EmissiveColor = new Vector3(color);
            mat.TransparentColor = new Vector3(color);
            scene.RootNode.ChildNodes[0].Material = mat;
            return scene;
        }
    }

}
