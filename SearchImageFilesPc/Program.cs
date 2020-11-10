using System;
using System.IO;
using System.Threading;

namespace SearchImageFilesPc
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchFolders searchFolders = new SearchFolders();
            searchFolders.StartScanning(@"C:\Users");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            Console.WriteLine("!--------------------------------------------------------------------------!\n");
            Console.WriteLine("Billeder fundet: " + searchFolders._imageCount);
            Console.WriteLine("\n!--------------------------------------------------------------------------!");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;


            Thread.Sleep(5000);
            foreach (var item in searchFolders.imageList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
