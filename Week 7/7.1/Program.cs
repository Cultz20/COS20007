using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Enter your name: ");
            string pName = Console.ReadLine();
            Console.Write("Enter your description: ");
            string pDesc = Console.ReadLine();
            Player player = new Player(pName, pDesc);

            Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
            Item bronze_shovel = new Item(new string[] { "shovel" }, "bronze shovel", "a bronze shovel");
            player.Inventory.Put(bronze_sword);
            player.Inventory.Put(bronze_shovel);

            Bag bag = new Bag(new string[] { "bag" }, "Leather Bag", "a small leather chest");
            player.Inventory.Put(bag);
            Item potion = new Item(new string[] { "potion" }, "Health Potion", "a medium health potion");
            bag.inventory.Put(potion);


            Console.WriteLine("\nYou can use 'look' to see your surroundings, 'look in bag', or 'quit'.");
            string command;
            do
            {
                Console.Write("\nEnter command: ");
                command = Console.ReadLine().ToLower();

                if (command == "look")
                {
                    Console.WriteLine(player.FullDescription);
                }
                else if (command.StartsWith("look in "))
                {
                    string target = command.Substring(8);
                    GameObject found = player.Locate(target);
                    if (found is Bag foundBag)
                    {
                        Console.WriteLine(foundBag.FullDescription);
                    }
                    else
                    {
                        Console.WriteLine("You don't see that here.");
                    }
                }
            } while (command != "quit");

            Console.WriteLine("Goodbye!");
        }
    }
}
