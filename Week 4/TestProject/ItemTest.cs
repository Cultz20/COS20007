using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Iterations;

namespace TestProject
{
    [TestFixture]
    public class ItemUnitTests
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
            string expected = "a bronze sword (sword)";
            Assert.AreEqual(expected, testItem.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            string expected = "A finely crafted bronze sword.";
            Assert.AreEqual(expected, testItem.FullDescription);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            string studentId = "12345678";
            string inputPin = "5678"; // Last 4 digits of student ID

            Assert.AreEqual("12345678", GetTutorialID(studentId, inputPin));

            string wrongPin = "1234";
            Assert.AreNotEqual("12345678", GetTutorialID(studentId, wrongPin));
        }

        private string GetTutorialID(string studentId, string inputPin)
        {
            return studentId.EndsWith(inputPin) ? studentId : "Access Denied";
        }
    }
}