using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class Player : GameObject
    {
        Inventory _inventory;

        public Player(string name, string desc) :base(new string[] {"me", "inventory"}, name, desc)
        {
            Name = name;
            Description = desc;
            _inventory = new Inventory();
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"{Name}, you are {Description}. You are carrying: {_inventory.ItemList}";
            }
        }
        public Inventory Inventory
        {
            get { return _inventory; }

        }
    }
}
