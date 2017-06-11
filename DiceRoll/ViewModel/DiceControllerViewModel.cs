using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceRoll.Model;
using GalaSoft.MvvmLight;

namespace DiceRoll.ViewModel
{
    public class DiceControllerViewModel: ViewModelBase
    {
        public DiceControllerViewModel()
        {
           
        }

        private ObservableCollection<DiceCounter> _diceTypeList;

        public ObservableCollection<DiceCounter> DiceTypeList
        {
            get { return _diceTypeList; }
            set { _diceTypeList = value; }
        }
    }
}
