using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Iterations;

namespace TestIteration
{
    [TestFixture]
    public class InventoryTest
    {
        private Item bronze_sword = new Item(new string[] { "sword" }, "bronze sword", "a bronze sword");
        private Item bronze_shovel = new Item(new string[] { "shovel" }, "bronze shovel", "a bronze shovel");
        private Inventory inventory;
        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
        }

        [Test]
        public void TestFindItem()
        {
            inventory.Put(bronze_sword);
            Assert.IsTrue(inventory.HasItem("sword"));
        }
        [Test]
        public void TestNoItemFind()
        {
            Assert.IsFalse(inventory.HasItem("shovel"));
        }
        [Test]
        public void TestFetchItem()
        {
            inventory.Put(bronze_shovel);
            Item itemFetched = inventory.Fetch("shovel");
            Assert.IsNotNull(itemFetched);
            Assert.That(itemFetched, Is.EqualTo(bronze_shovel));
            Assert.IsTrue(inventory.HasItem("shovel"));
        }
        [Test]
        public void TestTakeItem()
        {
            inventory.Put(bronze_shovel);
            Item itemTaken = inventory.Take("shovel");
            Assert.IsNotNull(itemTaken);
            Assert.That(itemTaken, Is.EqualTo(bronze_shovel));
            Assert.IsFalse(inventory.HasItem("shovel"));
        }
        [Test]
        public void TestItemList()
        {
            inventory.Put(bronze_shovel);
            inventory.Put(bronze_sword);
            string expected = "bronze shovel, bronze sword";
            Assert.That(inventory.ItemList, Is.EqualTo(expected));
        }
    }
}
