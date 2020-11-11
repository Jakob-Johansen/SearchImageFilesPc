using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchImageFilesPc
{
    public class TestSearchFolders
    {
        private readonly string[] ImageFormatArray = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".eps", ".raw", ".cr2", ".crw", ".nef", ".pef", ".tiff", ".webp" };

        public int _imageCount;

        public List<string> imageList;

        private readonly Logs _log;

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

                            string newFileName = Guid.NewGuid() + "-kopi" + fileExtension;

                            // Tilføj validering
                            try
                            {
                                File.Copy(item, @"D:\CopyTo\" + newFileName);
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

        //private void KillClone(string path, string filename, string extension)
        //{
        //    if (filename.Contains("-kopi"))
        //    {
        //        File.Delete(path + filename + extension);
        //    }
        //}

    }
}
