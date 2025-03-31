using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"})
        {

        }
        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 0 || text[0] != "look")
                return "Error in look input";
            if (text.Length != 3 && text.Length != 5)
                return "I don't know how to look like that";
            if (text[1] != "at")
                return "What do you want to look at?";
            if (text.Length == 5 && text[3] != "in")
                return "What do you want to look in?";

            IHaveInventory container = (text.Length == 3) ? p : FetchContainer(p, text[4]);

            if (container == null)
                return $"I cannot find the {text[4]}";

            return LookAtIn(text[2], container);
        }

        private IHaveInventory? FetchContainer(Player p, string containerId)
        {
            IHaveInventory? container = p.Locate(containerId) as IHaveInventory;
            if (container == null)
                return null;

            return container;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container == null)
                return "Error: Container is null"; // Safety check

            GameObject item = container.Locate(thingId);
            if (item == null)
                if (container is Player)
                    return $"I cannot find the {thingId}";
                else
                    return $"I cannot find the {thingId} in the {container.Name}";

            return item.ToString();
        }

    }
}
