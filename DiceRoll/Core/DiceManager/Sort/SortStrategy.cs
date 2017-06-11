using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceRoll.Core.DiceManager.Sort;
using DiceRoll.Model;

namespace DiceRoll.Core.DiceManager
{
    public abstract class SortStrategy
    {
        public abstract void Sort(ICollectionView diceCollection);
    }
}
