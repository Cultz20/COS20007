using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class GameObject : IdentifiableObject
    {
        string _description;
        string _name;
        public GameObject(string[]ids, string name, string desc) : base(ids) 
        {
            _name = name;
            _description = desc;    
        }

        public string Name => _name;
        public string ShortDescription => $"{Name} ({identifiers.FirstOrDefault()})";
        public virtual string FullDescription => $"{Name} : {_description}";
    }
}
