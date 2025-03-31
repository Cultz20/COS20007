using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            return _items.Any(item => item.AreYou(id));
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            Item item = _items.FirstOrDefault(i => i.AreYou(id));
            if (item != null)
            {
                _items.Remove(item);
            }
            return item;
        }

        public Item Fetch(string id)
        {
            return _items.FirstOrDefault(i => i.AreYou(id));
        }

        public string ItemList
        {
            get { return string.Join(", ", _items.Select(i => i.Name)); }
        }
    }
}
