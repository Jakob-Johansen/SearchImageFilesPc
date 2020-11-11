using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SearchImageFilesPc
{
    public class CopyFile
    {
        private readonly string[] _formatArray = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".eps", ".raw", ".cr2", ".crw", ".nef", ".pef", ".tiff" };

        public void RunProgram(string pathWhitFileName)
        {
            string fileExtension = Path.GetExtension(pathWhitFileName).ToLower();

            foreach (var item in _formatArray)
            {
                if (fileExtension.Contains(item))
                {
                    string fileName = pathWhitFileName.Split('\\').Last().Split('.').First();

                    string newFileName = fileName + "-kopi" + fileExtension;

                    Console.WriteLine(newFileName);

                    string path = pathWhitFileName.Split(fileName).First();

                    File.Copy(pathWhitFileName, path + newFileName);

                    Directory.Move(path + newFileName, @"C:\Users\Monosoft\Desktop\CopyTo\" + newFileName);
                }
            }
        }
    }
}
