using System;
using System.IO;
using System.Threading;

namespace SearchImageFilesPc
{
    class Program
    {


        static void Main(string[] args)
        {
            TestSearchFolders testSearchFolders = new TestSearchFolders();
            testSearchFolders.StartScanning(@"C:\Users\");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n!--------------------------------------------!");
            Console.WriteLine("Billeder: " + testSearchFolders._imageCount);
            Console.WriteLine("!--------------------------------------------!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }


        //static void Main(string[] args)
        //{
        //    SearchFolders searchFolders = new SearchFolders();
        //    searchFolders.StartScanning(@"C:\Users\Monosoft\Desktop\Test");

        //    foreach (var item in searchFolders.imageList)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine("\n");
        //    Console.WriteLine("!--------------------------------------------------------------------------!\n");
        //    Console.WriteLine("Billeder fundet: " + searchFolders._imageCount);
        //    Console.WriteLine("\n!--------------------------------------------------------------------------!");
        //    Console.WriteLine("\n");
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //}
    }
}
