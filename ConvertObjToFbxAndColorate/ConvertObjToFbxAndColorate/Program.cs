using System.IO;
using System.Collections.Generic;

namespace ConvertObjToFbxAndColorate
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceFilesCollection = Directory.GetFiles(@"D:\Projects\aibolit-src\ObjToFbx\3D model from CT");
            Converter.ConverteFromObjToFbx(
                    sourceFilesCollection,
                    "./test.fbx"
                    );
        }
    }
}
