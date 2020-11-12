using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchImageFilesPc
{
    public class Logs
    {
        private readonly string _folderPath;

        public Logs()
        {
            _folderPath = GetFolderPath();
        }

        public void CreateLog(string fileName,string execption, string path)
        {
            string logContainerString = "!==============================================!";

            using StreamWriter sw = File.AppendText(_folderPath);
            sw.WriteLine(logContainerString);
            sw.WriteLine("Filename: " + fileName);
            sw.WriteLine("Execption Message: " + execption);
            sw.WriteLine("Path: " + path);
            sw.WriteLine(logContainerString + "\n");
        }

        public void CreateLog(string execption, string path)
        {
            string logContainerString = "!==============================================!";

            using StreamWriter sw = File.AppendText(_folderPath);
            sw.WriteLine(logContainerString);
            sw.WriteLine("Execption Message: " + execption);
            sw.WriteLine("Path: " + path);
            sw.WriteLine(logContainerString + "\n");
        }

        private string GetFolderPath()
        {
            string[] mainFolderPath = Directory.GetCurrentDirectory().Split('\\');

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in mainFolderPath)
            {
                if (item.ToLower() == "bin")
                {
                    break;
                }

                stringBuilder.Append(item + "\\");
            }

            stringBuilder.Append("Logs\\");

            string path = CreatePathAndFile(stringBuilder.ToString());

            return path;
        }

        private string CreatePathAndFile(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);

                fullPath += "log.txt";

                using FileStream fileStream = File.Create(fullPath);

                return fullPath;
            }

            return fullPath + "log.txt";
        }
    }
}
