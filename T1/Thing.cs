using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1
{
    internal abstract class Thing
    {
        private string _name;
        protected Thing(string name)
        { _name = name; }
        public abstract int Size();
        public abstract void Print();

        public string Name => _name;
    }
}