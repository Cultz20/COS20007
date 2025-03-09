using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class FileSystem
    {
        private List<Thing> _contents;

        public FileSystem() 
        {
            _contents = new List<Thing>();
        }

        public void AddThing(Thing toAdd)
        {  _contents.Add(toAdd); }

        public void PrintContents()
        {
            Console.WriteLine("This file System Contains:");
            foreach (var item in _contents)
            {
                item.Print();
            }
        }
    }
}
