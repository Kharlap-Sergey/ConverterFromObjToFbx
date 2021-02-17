using Aspose.ThreeD;
using Aspose.ThreeD.Formats;
using Aspose.ThreeD.Shading;
using Aspose.ThreeD.Utilities;
using System.Collections.Generic;

namespace ConvertObjToFbxAndColorate
{
    public class Converter
    {

        public static void ConverteFromObjToFbx(IEnumerable<string> fromPathCoollerction, string to)
        {
            var mainDocument = new Scene();
            
            foreach(var path in fromPathCoollerction )
            {
                var document = new Scene(path);
                mainDocument.RootNode.AddChildNode(document.RootNode);

            }
            var options = new FBXSaveOptions(FileFormat.FBX7500Binary);
            mainDocument.Save(to, options);
        }
    }
}
