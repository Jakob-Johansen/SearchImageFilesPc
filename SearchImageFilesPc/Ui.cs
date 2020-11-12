using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchImageFilesPc
{
    public class Ui
    {
        private bool _pathToScanBool = false;

       
        private bool _copyPicToBool = false;

        public void RunUi()
        {
            Console.WriteLine("Scan din pc for billeder program.\n");

            string scanPath = UserInputValidate("Scan: ", _pathToScanBool);
            string copyPath = UserInputValidate("Kopir til: ", _copyPicToBool);

            Thread.Sleep(3000);
            Console.Clear();

            TestSearchFolders testSearchFolders = new TestSearchFolders(scanPath, copyPath);
            testSearchFolders.StartScanning();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n!--------------------------------------------!");
            Console.WriteLine("Billeder: " + testSearchFolders._imageCount);
            Console.WriteLine("!--------------------------------------------!\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadLine();
        }

        private string UserInputValidate(string message, bool setToTrue)
        {
            string userInput = string.Empty;
            while (setToTrue == false)
            {
                Console.Write(message);
                userInput = Console.ReadLine().Trim();

                if (Directory.Exists(userInput) && Path.GetExtension(userInput).Length == 0)
                {
                    setToTrue = true;
                    userInput = ValidatePath(userInput);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Stigen er gyldig.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Du skal skrive en gyldig mappe stig.\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            return userInput; 
        }

        private string ValidatePath(string path)
        {
            char[] pathCharArray = path.ToCharArray();

            for (int i = 0; i < pathCharArray.Length; i++)
            {
                if (i == path.Length - 1 && pathCharArray[i].ToString() != "\\")
                {
                    return path += "\\";
                }
            }

            return path;
        }
    }
}
