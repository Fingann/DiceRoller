using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Markup;
using DiceRoll.Core.DiceManager;

namespace DiceRoll.Model
{
    public class DataService : IDataService
    {
        public DiceManager DiceManager { get; set; }

        public DataService()
        {
            DiceManager = new DiceManager();
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public void GetDiceCollection(Action<ICollectionView, Exception> callback)
        {
            throw new NotImplementedException();
        }

        public void GetDiceCollection(Action<ObservableDiceCollection, Exception> callback)
        {
            // Use this to connect to the actual data service

            callback(DiceManager.Dices, null);
        }



        //public  Task<IEnumerable<Dice>> GetDices(IEnumerable<Dice> dices)
        //{

        //    //var dices = new List<Dice>() { new Dice(6), new Dice(100), new Dice(10) };
        //    DiceRoller roller = new DiceRoller(dices);

        //    return roller.Roll();

        //}
    }
}