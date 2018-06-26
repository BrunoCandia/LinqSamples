using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";

            ShowLargeFilesWithoutLinq(path);

            Console.WriteLine("**********");

            ShowLargeFilesWithLinq(path);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void ShowLargeFilesWithLinq(string path)
        {
            var querySyntax = from file in new DirectoryInfo(path).GetFiles()
                              orderby file.Length descending
                              select file;

            foreach (var file in querySyntax.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }

            Console.WriteLine("**********");

            var methodSyntax = new DirectoryInfo(path).GetFiles()
                        .OrderByDescending(f => f.Length)
                        .Take(5);

            foreach (var file in methodSyntax)
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());

            for (int i = 0; i < 5; i++)
            {
                var file = files[i];
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }

            //foreach (var file in files)
            //{
            //    Console.WriteLine($"{file.Name} : {file.Length}");
            //}
        }
    }

    public class FileInfoComparer : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}
