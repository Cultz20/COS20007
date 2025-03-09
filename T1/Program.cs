using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string studentID = "104773652";
            int[] A = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
            int[] B = { 7, 17, 13, 5 };

            FileSystem fileSystem = new FileSystem();


            for (int i = 0; i < B[0]; i++)
            {
                fileSystem.AddThing(new File($"{studentID}-{i:00}.txt", "txt", 100));
            }

            Folder folder1 = new Folder("Folder1");
            for (int i = 0; i < B[1]; i++)
            {
                folder1.Add(new File($"{studentID}-{i:00}.txt", "txt", 200));
            }
            fileSystem.AddThing(folder1);

            Folder Folder_1 = new Folder("Folder_1");
            Folder Folder_2 = new Folder("Folder_2");
            for (int i = 0; i < B[2]; i++)
            {
                Folder_2.Add(new File($"{studentID}-{i:00}.txt", "txt", 300));
            }
            Folder_1.Add(Folder_2);
            fileSystem.AddThing(Folder_1);

            for (int i = 0; i < B[3]; i++)
            {
                fileSystem.AddThing(new Folder($"EmptyFolder-{i}"));
            }

            fileSystem.PrintContents();
        }
    }
}
