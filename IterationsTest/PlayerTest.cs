using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iterations;
using NUnit.Framework;


namespace TestIteration
{
    [TestFixture]
    public class PlayerTest
    {
        private Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
        private Item bronze_shovel = new Item(new string[] { "shovel" }, "bronze shovel", "a bronze shovel");
        private Player player = new Player("Me", "an adventurer");

        [SetUp]
        public void Setup()
        {
            player.Inventory.Put(bronze_sword);
            player.Inventory.Put(bronze_shovel);
        }
        [Test]
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(player.AreYou("me"));
            Assert.IsTrue(player.AreYou("inventory"));
        }
        [Test]
        public void TestPlayerLocatesItems()
        {
            Assert.That(player.Locate("sword"), Is.EqualTo(bronze_sword));
            Assert.That(player.Locate("shovel"), Is.EqualTo(bronze_shovel));
            Assert.IsTrue(player.Inventory.HasItem("sword"));
            Assert.IsTrue(player.Inventory.HasItem("shovel"));
        }
        [Test]
        public void TestPlayerLocatesItSelf() 
        {
            Assert.That(player.Locate("me"), Is.EqualTo(player));
            Assert.That(player.Locate("inventory"), Is.EqualTo(player));
        }
        [Test]
        public void TestPlayerLocatesNothing()
        {
            Assert.IsNull(player.Locate("helmet"));
            Assert.IsNull(player.Locate("chestplate"));
        }
        [Test]
        public void TestPlayerFullDescription()
        {
            string expected = "Me, you are an adventurer. You are carrying: bronze sword, bronze shovel";
            Assert.That(player.FullDescription, Is.EqualTo(expected));
        }
    }
}
