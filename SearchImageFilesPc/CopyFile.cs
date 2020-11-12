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

        public void RunProgram(string pathWithFileName)
        {
            string fileExtension = Path.GetExtension(pathWithFileName).ToLower();

            foreach (var item in _formatArray)
            {
                if (fileExtension.Contains(item))
                {
                    string fileName = pathWithFileName.Split('\\').Last();

                    Console.WriteLine(fileName);

                    string path = pathWithFileName.Split(fileName).First();
                    Console.WriteLine(path);
                }
            }
        }
    }
}
