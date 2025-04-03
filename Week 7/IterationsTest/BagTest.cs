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
    public class BagTest
    {
        private Bag chest = new Bag(new string[] { "chest" }, "Wooden Chest", "a wooden chest");
        private Item potion = new Item(new string[] { "potion" }, "Health Potion", "a medium health potion");
        private Item scroll = new Item(new string[] { "scroll" }, "Fireball Scroll", "a magic fireball scroll");


        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void TestBagLocatesItems()
        {
            chest.inventory.Put(potion);
            chest.inventory.Put(scroll);

            Assert.That(chest.Locate("potion"), Is.EqualTo(potion));
            Assert.That(chest.Locate("scroll"), Is.EqualTo(scroll));
            Assert.IsTrue(chest.inventory.HasItem("potion"));
            Assert.IsTrue(chest.inventory.HasItem("scroll"));
        }
        [Test]
        public void TestBagLocatesItself()
        {
            Assert.That(chest.Locate("chest"), Is.EqualTo(chest));
        }
        [Test]
        public void TestBagLocatesNothing()
        {
            Assert.IsNull(chest.Locate("consumable"));
        }
        [Test]
        public void TestBagFullDescription()
        {
            chest.inventory.Put(potion);
            chest.inventory.Put(scroll);

            string expected = "In the Wooden Chest, you can see: Health Potion, Fireball Scroll";
            Assert.That(chest.FullDescription, Is.EqualTo(expected));
        }
        [Test]
        public void TestBaginBag()
        {
            Bag bag = new Bag(new string[] { "bag" }, "Leather Bag", "a small leather chest");
            
            bag.inventory.Put(potion);
            chest.inventory.Put(bag);

            Assert.That(chest.Locate("bag"), Is.EqualTo(bag));
            Assert.That(bag.Locate("potion"), Is.EqualTo(potion));
        }
    }
}
