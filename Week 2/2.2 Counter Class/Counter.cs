using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2_Counter_Class
{
    public class Counter
    {
        private long _count;
        private string _name;
        public string Name
        {  
            get
            { 
                return _name; 
            }
            set
            {
                _name = value;
            }
        }
        public string Ticks
        {
            get
            {

                return _count.ToString();
            }
            set
            {
                _count = Convert.ToInt32(value);
            }
        }

        public Counter(string name)
        {
            _name = name;
            _count = 0;
        }

        public void Increment()
        {
            int increLoop = 1;
            for (int i = 0; i < increLoop; i++);
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
        public void ResetByDefault()
        {
            _count = 2147483647751;
            //XXX is 751 -> overflow
            //Code bugged because it reached the interger limit (Cannot convert type long to int)
            //Fix: private int _count; -> private long _count;
        }

    }
}
