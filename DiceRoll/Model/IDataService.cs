using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);

        void GetDiceCollection(Action<ICollectionView, Exception> callback);


        //Task<IEnumerable<Dice>> GetDices(IEnumerable<Dice> dices);
    }
}
