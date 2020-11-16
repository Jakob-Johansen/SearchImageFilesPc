using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SearchImageFilesPc
{
    public class FirstVersionSearchFolders
    {
        private readonly string[] ImageFormatArray = new string[] { "jpg", "jpeg", "png", "gif", "eps", "raw", "cr2", "crw", "nef", "pef", "tiff" };

        public int _imageCount;

        public List<string> imageList;

        public FirstVersionSearchFolders()
        {
            _imageCount = 0;
            imageList = new List<string>();
        }

        public void StartScanning(string folderPath)
        {
            Console.WriteLine("Scanning Startet.\n");
            FolderScan(folderPath);
        }

        private void FolderScan(string folderPath)
        {
            var allFolders = Directory.GetFileSystemEntries(folderPath);

            foreach (var item in allFolders)
            {
                try
                {
                    var test = Path.GetExtension(item).Split('.').Last();
                    foreach (var format in ImageFormatArray)
                    {
                        if (test.ToLower().Contains(format))
                        {
                            _imageCount += 1;
                            imageList.Add(item);
                        }
                    }

                    if (Directory.Exists(item))
                    {
                        Console.WriteLine(item);
                        FolderScan(item);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
