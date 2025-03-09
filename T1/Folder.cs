using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class Folder : Thing
    {
        private List<Thing> _contents;

        public Folder(string name) : base(name)
        { _contents = new List<Thing>(); }

        public void Add(Thing toAdd)
        { _contents.Add(toAdd); }

        public override int Size()
        {
            int totalSize = 0;
            foreach (var item in _contents)
            {
                totalSize += item.Size();
            }
            return totalSize;
        }

        public override void Print()
        {

            if (_contents.Count == 0)
            {
                Console.WriteLine($"The Folder: {Name} is empty!");
            }
            else
            {
                int totalSize = Size();
                Console.WriteLine($"The Folder: {Name} (contains {_contents.Count} files totaling {totalSize} bytes)");

                foreach (var item in _contents)
                {
                    item.Print();
                }
            }
        }
    }
}
