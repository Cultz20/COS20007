using System.Xml.Linq;
//Program.cs
namespace _1._2_Hello_World
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Message myMessage = new Message("Hello, World! Greetings from Message Object. My student ID is SWH01751");
            myMessage.Print();
            Console.WriteLine("Enter your name:");

            string name = Console.ReadLine();
            string[] response = { "Hi ", ", how are you?", "Welcome Admin", "Welcome, nice to meet you" };

            if (name == "James Bond" | name == "Jason Bourne" | name == "John Wick") {
                    Console.WriteLine(response[0] + name + response[1]);
                }
            else if (name == "Kiet") {
                    Console.WriteLine(response[2]);
                }
            else {
                    Console.WriteLine(response[3]);
                }
        }
    }
}
