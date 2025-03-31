using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterations;
using NUnit.Framework;

namespace IterationsTest
{
    [TestFixture]
    public class LookCommandTest
    {
        private Player player = new Player("Me", "an adventurer");
        private Bag bag = new Bag(new string[] { "bag" }, "Leather Bag", "a small leather chest");
        private Item gem = new Item(new string[] { "gem" }, "Peridot", "a shiny flawless peridot");
        private LookCommand lookcmd = new LookCommand();

        [SetUp]
        public void Setup()
        {
            player.Inventory.Put(bag);
            bag.inventory.Put(gem);
        }
        [Test]
        public void TestLookAtMe()
        {
            string result = lookcmd.Execute(player, new string[] { "look", "at", "inventory" });
            Assert.That(result, Is.EqualTo(player.ToString()));
        }
        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem" });
            Assert.That(result, Is.EqualTo(gem.ToString()));
        }
        [Test]
        public void TestLookAtUnk()
        {
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem" });
            Assert.That(result, Is.EqualTo("I cannot find the gem"));
        }
        [Test]
        public void TestLookAtGemInMe()
        {
            player.Inventory.Put(gem);
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem", "in", "me" });
            Assert.That(result, Is.EqualTo(gem.ToString()));
        }
        [Test]
        public void TestLookAtGemInBag()
        {
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo(gem.ToString()));
        }
        [Test]
        public void TestLookAtGemInNoBag()
        {
            player.Inventory.Take("bag");
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo("I cannot find the bag"));
        }
        [Test]
        public void TestLookAtNoGemInBag()
        {
            bag.inventory.Take("gem");
            string result = lookcmd.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            Assert.That(result, Is.EqualTo("I cannot find the gem in the Leather Bag"));
        }
        [Test]
        public void TestInvalidLook()
        {
            string result1 = lookcmd.Execute(player, new string[] { "look", "around" });
            string result2 = lookcmd.Execute(player, new string[] { "hello" });
            string result3 = lookcmd.Execute(player, new string[] { "look", "at", "a", "at", "b" });

            Assert.That(result1, Is.EqualTo("I don't know how to look like that"));
            Assert.That(result2, Is.EqualTo("Error in look input"));
            Assert.That(result3, Is.EqualTo("What do you want to look in?"));
        }
    }
}
