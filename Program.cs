using System;
using System.Collections.Generic;
using System.IO;

namespace RenameImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "";
            string imagesFolder = "";
            int counter = 0;

            Console.WriteLine("Enter path to pictures folder: ");
            imagesFolder = Console.ReadLine();

            Console.WriteLine("Enter path to txt file with names: ");
            fileName = Console.ReadLine();

            List<string> names = new List<string>();


            string text = File.ReadAllText(fileName + ".txt");
            string[] lines = text.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                names.Add(line);
            }

            DirectoryInfo di = new DirectoryInfo($@"{imagesFolder}");
            FileInfo[] files = di.GetFiles("*.png");

            foreach (FileInfo file in files)
            {
                file.MoveTo($"{imagesFolder}/{names[counter]}.png");
                counter++;
            }
        }
    }
}
