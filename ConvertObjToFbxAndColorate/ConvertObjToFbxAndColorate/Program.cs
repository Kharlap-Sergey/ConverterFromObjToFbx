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
                "#272d47",
                "#03fc41",
                "#472729",
                "#fcba03",
                "#464727",
                "#274746"
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
