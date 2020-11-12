using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchImageFilesPc
{
    public class TestSearchFolders
    {
        private readonly string[] ImageFormatArray = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".eps", ".raw", ".cr2", ".crw", ".nef", ".pef", ".tiff", ".webp" };

        public int _imageCount;

        public List<string> imageList;

        private readonly Logs _log;
        private readonly string _CopyToFolderPath = @"D:\CopyTo\"; // D:\CopyTo\

        public TestSearchFolders()
        {
            _log = new Logs();
            _imageCount = 0;
            imageList = new List<string>();
        }

        public void StartScanning(string folderPath)
        {
            if (!Directory.Exists(_CopyToFolderPath) || _CopyToFolderPath.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\nMappen billederne skal kopiers til findes ikke.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                return;
            }

            Console.WriteLine("Scanning Startet.\n");
            FolderScan(folderPath);
        }

        private void FolderScan(string folderPath)
        {
            var allFolders = Directory.GetFileSystemEntries(folderPath);

            Guid folderId = Guid.NewGuid();

            foreach (var item in allFolders)
            {
                // Tjekker ikke inde i stien C:\Program Files\WindowsApps\
                if (!item.Contains(@"C:\Program Files\WindowsApps\"))
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(item);

                        string fileExtension = Path.GetExtension(item).ToLower();

                        foreach (var format in ImageFormatArray)
                        {
                            if (fileExtension == format)
                            {
                                string fileName = item.Split('\\').Last();

                                try
                                {
                                    string folderName = item.Split('\\' + fileName).First().Split('\\').Last();
                                    folderName = folderName + "---" + folderId;

                                    Console.WriteLine(folderName);

                                    if (!Directory.Exists(_CopyToFolderPath + folderName))
                                    {
                                        Directory.CreateDirectory(_CopyToFolderPath + folderName);
                                    }

                                    File.Copy(item, _CopyToFolderPath + folderName + "\\" + fileName);
                                }
                                catch (Exception e)
                                {
                                    _log.CreateLog(fileName, e.Message, item);
                                }

                                _imageCount += 1;
                                imageList.Add(item);
                            }
                        }

                        if (Directory.Exists(item))
                        {
                            FolderScan(item);
                        }
                    }
                    catch (Exception e)
                    {
                        _log.CreateLog(e.Message, item);
                    }
                }

            }
        }
    }
}
