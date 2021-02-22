using System.IO;
using System.Collections.Generic;
using Solver;

namespace ConvertObjToFbxAndColorate
{
    class Program
    {
        static void Main(string[] args)
        {
            //files location
            var pathToDerictory = @"D:\Projects\aibolit-src\ObjToFbx\3D model from CT";

            //all files from location
            var sourceFilesCollection = Directory.GetFiles(pathToDerictory);

            //define a mock colors
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

            //custom class to represent 3d object and required color
            var ThreeDModelCollection = new List<ThreeDModelRepresenter>();

            //map colors with files 
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

            //execute 
            Converter.MergeAndColorateObjFilesToFbxFile(
                    ThreeDModelCollection,
                    "./test.fbx"
                    );
        }
    }
}
