using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Model
{
    public class ObservableDiceCollection: ObservableCollection<Dice>
    {
        public ObservableDiceCollection(): base()
        {
            
        }
        public ObservableDiceCollection(IEnumerable<Dice> diceCollection) : base(diceCollection)
        {

        }

        public IEnumerable<Dice> GetAllOfType(DiceType type)
        {
            return Items.Where(x => x.DiceType == type);
        }

        public int DiceTotal()
        {
            return Items.Select(x=> x.Result).Aggregate((a, b) => a + b);
        }

        public int DiceTotalOfType(DiceType type)
        {
            return Items.Where((x) => x.DiceType == type).Select(x => x.Result).Aggregate((a, b) => a + b);
        }

    }
}
