using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using DiceRoll.Core.DiceManager.Sort;
using DiceRoll.Model;

namespace DiceRoll.Core.DiceManager
{
    public class DiceSorter
    {
        private ObservableDiceCollection ObservableDiceCollection { get; set; }
        private SortStrategy _sortstrategy;
        private ICollectionView _diceView;

        public ICollectionView DiceView
        {
            get { return _diceView; }
            set { _diceView = value; }
        }

        

        public DiceSorter(ObservableDiceCollection collection)
        {
            ObservableDiceCollection = collection;
            _diceView = CollectionViewSource.GetDefaultView(ObservableDiceCollection);
            SetSortStrategy(new SortBySides(ListSortDirection.Ascending));

        }

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            using (_diceView.DeferRefresh())
            {
                if (_diceView.SortDescriptions.Count > 0)
                {
                    _diceView.SortDescriptions.Clear();
                }
                this._sortstrategy = sortstrategy;
                Sort();
            }
        }

        private void Sort()
        {
            using (_diceView.DeferRefresh())
            {
                _sortstrategy.Sort(_diceView);
            }
            

        }
    }
}
