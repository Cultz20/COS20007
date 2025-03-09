using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal class File : Thing
    {
        private string _extension;
        private int _size;

        public File (string filename, string extension, int size )  : base(filename)
        { 
            _extension = extension;
            _size = size;
        }
        public override int Size()
        { return _size; }

        public override void Print()
        { Console.WriteLine($"File: {Name}.{_extension}, Size: {_size} bytes"); }
    }
}
