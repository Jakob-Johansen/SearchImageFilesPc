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
        private readonly string _CopyToFolderPath = @"D:\CopyTo\";

        public TestSearchFolders()
        {
            _log = new Logs();
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

            Guid folderId = Guid.NewGuid();
            foreach (var item in allFolders)
            {
                try
                {
                    Console.WriteLine(item);

                    string fileExtension = Path.GetExtension(item).ToLower();

                    foreach (var format in ImageFormatArray)
                    {
                        if (fileExtension.Contains(format))
                        {
                            string fileName = item.Split('\\').Last().Split('.').First();

                            string newFileName = fileName + "---" + Guid.NewGuid() + fileExtension;

                           // Tilføj validering
                            try
                            {
                                string folderName = item.Split('\\' + fileName).First().Split('\\').Last();
                                Console.WriteLine(folderName);

                                if (!Directory.Exists(_CopyToFolderPath + folderName + "---" + folderId))
                                {
                                    Directory.CreateDirectory(_CopyToFolderPath + folderName + "---" + folderId);
                                }

                                File.Copy(item, _CopyToFolderPath + folderName + "---" + folderId + "\\" + newFileName);
                            }
                            catch (Exception e)
                            {
                                _log.CreateLog(e.Message);
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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
