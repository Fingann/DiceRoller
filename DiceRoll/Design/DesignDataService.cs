using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using DiceRoll.Model;

namespace DiceRoll.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void GetDiceCollection(Action<ICollectionView, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Dice>> GetDices(IEnumerable<Dice> dices)
        {
            var task = Task.FromResult(new List<Dice>()
            {
                new Dice(6),
                new Dice(100),
                new Dice(10),
                new Dice(8),
                new Dice(7)
            } as IEnumerable<Dice>);
           return task;
        }

       
    }
}