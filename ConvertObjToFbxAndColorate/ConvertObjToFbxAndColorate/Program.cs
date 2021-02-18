using System.IO;
using System.Collections.Generic;

namespace ConvertObjToFbxAndColorate
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilesCollection = Directory.GetFiles(@"D:\Projects\aibolit-src\ObjToFbx\3D model from CT");
            var Colors = new List<string>
            {
                "#d4d85b",
                "#183cd5",
                "#fe020b",
                "#3f7c39",
                "#f9e6a3",
                "#a9d1de",
                "#ffc27a",
                "#c4c4c4",
                "#e346ff",
                "#ff6f29",
            };

            var ThreeDModelCollection = new List<ThreeDModelRepresenter>();

            for(int i = 0; i < sourceFilesCollection.Length; i++ )
            {
                ThreeDModelCollection.Add(
                    new ThreeDModelRepresenter
                    {
                        PathToModel = sourceFilesCollection[i],
                        ColorHexFromat = Colors[i % Colors.Count]
                    }
                    );
                ;
            }

            Converter.ConverteFromObjToFbx(
                    ThreeDModelCollection,
                    "./test.fbx"
                    );
        }
    }
}
