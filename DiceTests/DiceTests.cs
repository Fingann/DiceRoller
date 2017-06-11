using System;
using System.Text;
using System.Collections.Generic;
using DiceRoll.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiceTests
{
    /// <summary>
    /// Summary description for DiceTests
    /// </summary>
    [TestClass]
    public class DiceTests
    {
        public DiceTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Dice_Name_Test()
        {
            var dice = new Dice(10);
            Assert.AreEqual("D10", dice.DiceName);
        }

        [TestMethod]
        public void Dice_Right_Type_Test()
        {
            var dice = new Dice(10);
            Assert.AreEqual(DiceType.D10, dice.DiceType);
        }

        [TestMethod]
        public void Dice_Custom_Type_Test()
        {
            var dice = new Dice(11);
            Assert.AreEqual(DiceType.CustomDice, dice.DiceType);
        }
    }
}
