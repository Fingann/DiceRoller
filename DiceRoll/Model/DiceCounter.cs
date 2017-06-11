using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Model
{
    public class DiceCounter: INotifyPropertyChanged
    {
        private string _diceName;
        private int _count = 0;
        private int _numberOfSides;

        public DiceCounter(int sides)
        {
            NumberOfSides = sides;
        }

        public string DiceName
        {
            get { return "D"+_numberOfSides; }
           
        }

        public int NumberOfSides
        {
            get { return _numberOfSides; }
            set
            {
                _numberOfSides = value;
                OnPropertyChanged(nameof(NumberOfSides));
            }
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
