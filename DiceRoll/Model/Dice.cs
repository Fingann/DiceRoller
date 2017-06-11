using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DiceRoll.Annotations;
using GalaSoft.MvvmLight;

namespace DiceRoll.Model
{
    public class Dice : Entity, INotifyPropertyChanged
    {
        private int _result;
        private int _diceSides;
        private DiceType _diceType = DiceType.CustomDice;

        public Dice(int diceSides)
        {
            DiceSides = diceSides;
            CalculateType();
        }

        public string DiceName => "D" + DiceSides;

        public int Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
                OnPropertyChanged(nameof(DiceName));
            }
        }

        public int DiceSides
        {
            get { return _diceSides; }
            set
            {
                _diceSides = value;
                OnPropertyChanged(nameof(DiceSides));
                OnPropertyChanged(nameof(DiceName));
            }
        }

        public DiceType DiceType
        {
            get { return _diceType; }
            set { _diceType = value; }
        }

        private void CalculateType()
        {
            foreach (int enumValue in Enum.GetValues(typeof(DiceType)))
            {
                if (enumValue == DiceSides )
                {
                    DiceType = (DiceType)enumValue;
                }
            }
        }

       

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}
