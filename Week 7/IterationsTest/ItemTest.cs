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
    public class ItemTests
    {
        private Item testItem;

        [SetUp]
        public void Setup()
        {
            string[] identifiers = { "sword", "weapon" };
            testItem = new Item(identifiers, "bronze sword", "A finely crafted bronze sword.");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(testItem.AreYou("sword"));
            Assert.IsTrue(testItem.AreYou("weapon"));
            Assert.IsFalse(testItem.AreYou("axe"));
        }

        [Test]
        public void TestShortDescription()
        {
            string expected = "bronze sword (sword)";
            Assert.AreEqual(expected, testItem.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            string expected = "bronze sword : A finely crafted bronze sword.";
            Assert.AreEqual(expected, testItem.FullDescription);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            string studentId = "SWH01751";
            string inputPin = "1751";

            Assert.AreEqual("SWH01751", GetTutorialID(studentId, inputPin));
        }

        private string GetTutorialID(string studentId, string inputPin)
        {
            return studentId.EndsWith(inputPin) ? studentId : "Access Denied";
        }
    }
}