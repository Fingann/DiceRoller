using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceRoll.Model;

namespace DiceRoll.Core.DiceManager
{
    public class DiceStatistics
    {
        public ObservableDiceCollection ObservableDiceCollection { get; set; }
        public DiceStatistics(ObservableDiceCollection collection)
        {
            ObservableDiceCollection = collection;
        }
        
        public int TypeCount(DiceType type)
        {
            return ObservableDiceCollection.GetAllOfType(type).Count();
        }

        public int TypeTotal(DiceType type)
        {
            return ObservableDiceCollection.DiceTotalOfType(type);
        }

        public int DiceResultTotal()
        {
            return ObservableDiceCollection.DiceTotal();
        }


    }
}
