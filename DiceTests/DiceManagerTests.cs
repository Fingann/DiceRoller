using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DiceRoll.Core.DiceManager;
using DiceRoll.Core.DiceManager.Sort;
using DiceRoll.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DiceTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void Dice_Initialization_Test()
        {
            List<Dice> list = new List<Dice> {new Dice(6), new Dice(100), new Dice(10), new Dice(8), new Dice(200)};
            DiceManager manager = new DiceManager(list);
            Assert.IsNotNull(manager.Dices);

            foreach (Dice dice in manager.Dices)
            {
                Assert.AreEqual(0, dice.Result);
            }


        }

        [Test]
        public void Dice_Sort_Test()
        {
            List<Dice> list = new List<Dice> {new Dice(6), new Dice(100), new Dice(10), new Dice(8), new Dice(200)};
            DiceManager manager = new DiceManager(list);
            manager.DiceSorter.SetSortStrategy(new SortBySides(ListSortDirection.Ascending));
            var sorted = new int[] {6, 8, 10, 100, 200};
            int count = 0;
            foreach (Dice dice in manager.DiceSorter.DiceView)
            {
                Assert.AreEqual(sorted[count], dice.DiceSides);
                count++;
            }

            manager.DiceSorter.SetSortStrategy(new SortBySides(ListSortDirection.Descending));
            
            count = sorted.Length;
            foreach (Dice dice in manager.DiceSorter.DiceView)
            {
                Assert.AreEqual(sorted[count - 1], dice.DiceSides);
                count--;
            }

        }

        [Test]
        public void Dice_Add_Test()
        {
            List<Dice> list = new List<Dice> {new Dice(6), new Dice(100), new Dice(10), new Dice(8), new Dice(200)};
            DiceManager manager = new DiceManager(list);
            var diceToAdd = new Dice(20);
            manager.AddDice(diceToAdd);

            Assert.IsTrue(manager.Dices.Contains(diceToAdd));
        }

        [Test]
        public void Dice_Remove_Test()
        {
            List<Dice> list = new List<Dice> {new Dice(6), new Dice(100), new Dice(6), new Dice(8), new Dice(200)};
            DiceManager manager = new DiceManager(list);
            
            var item = list[2];
            manager.RemoveDice(item);

            Assert.IsFalse(manager.Dices.Contains(item));


        }

        [Test]
        public async Task Dice_RollAll_Test()
        {
            List<Dice> list = new List<Dice> { new Dice(6), new Dice(100), new Dice(6), new Dice(8), new Dice(200) };
            DiceManager manager = new DiceManager(list);
            manager.AddDice(new Dice(11));
            await manager.RollAll();
            
            foreach (Dice dice in manager.Dices)
            {
              Assert.AreNotEqual(0,dice.Result);
            }

            
        }
    }
}
