using PlistCS;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var workspace = @"E:/game068/subgame".Replace("\\", "/");

            var files = Directory.GetFiles(workspace, "*.plist", SearchOption.AllDirectories);

            foreach(var path in files)
            {
                //var textureFileName = Path.GetFileNameWithoutExtension(path) + ".png";
                //var textureFilePath = Path.GetDirectoryName(path) + "/" + textureFileName;

                try
                {
                    var dict = Plist.readPlist(path) as Dictionary<string, object>;

                    if (!dict.ContainsKey("textureImageData") || !dict.ContainsKey("textureFileName"))
                        continue;

                    var textureImageData = dict["textureImageData"] as string;
                    if (textureImageData == "")
                        continue;

                    dict["textureFileName"] = "";
                    
                    //var bytes = Convert.FromBase64String(textureImageData);
                    //File.WriteAllBytes(textureFilePath, bytes);

                    Plist.writeXml(dict, path);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}