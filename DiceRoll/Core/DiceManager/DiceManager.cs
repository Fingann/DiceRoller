using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DiceRoll.Core.DiceManager.Sort;
using DiceRoll.Model;

namespace DiceRoll.Core.DiceManager
{
    public class DiceManager
    {
        private ObservableDiceCollection dices;
      
        private DiceRoller diceRoller;
        private DiceSorter diceSorter;
        private DiceStatistics diceStatistics;

        public DiceStatistics DiceStatistics
        {
            get { return diceStatistics; }
            set { diceStatistics = value; }
        }

        public DiceSorter DiceSorter
        {
            get { return diceSorter; }
            set { diceSorter = value; }
        }


        public ObservableDiceCollection Dices
        {
            get { return dices; }
            set { dices = value; }
        }

        public DiceManager() : this(new List<Dice>())
        {

        }

        public DiceManager(IEnumerable<Dice> dices)
        {
            this.dices = new ObservableDiceCollection(dices.ToList());
          
            diceRoller = new DiceRoller(this.dices);
            diceSorter = new DiceSorter(this.dices);
            diceStatistics = new DiceStatistics(this.dices);
        }

        public void AddDice(Dice dice)
        {
            this.dices.Add(dice);
            //DiceView.Refresh();
            //Sort();
        }

        public void RemoveDice(Dice dice)
        {
            this.dices.Remove(dice);
        }
        public void ClearDices()
        {
            this.dices.Clear();
        }
        
        public Task RollAll()
        {
              return diceRoller.Roll();
        }

      

        //public async Task<Dice> RollDice(Dice dice)
        //{
        //   return Task.Run(() => diceRoller.RollDice(dice));
        //}


    }
}
