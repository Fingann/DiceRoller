using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DiceRoll.Core;
using DiceRoll.Core.DiceManager;
using DiceRoll.Core.DiceManager.Sort;
using GalaSoft.MvvmLight;
using DiceRoll.Model;
using GalaSoft.MvvmLight.Command;

namespace DiceRoll.ViewModel
{
    /// <summary>
    /// This class contains properties that the main DiceView can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        public RelayCommand<string> AddDiceCommand { get; set; }

        public RelayCommand ClearDiceCommand { get; set; }
        public RelayCommand ClacluateDiceCommand { get; set; }
        private DiceManager diceManager;
        private ICollectionView _diceCollectionView;

        public DiceManager DiceManager
        {
            get { return diceManager; }
            set
            {
                diceManager = value;
                RaisePropertyChanged();
            }
        }

        public ICollectionView DiceCollectionView
        {
            get { return _diceCollectionView; }
            set
            {
                _diceCollectionView = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<DiceCounter> _diceTypeList;

        public ObservableCollection<DiceCounter> DiceTypeList
        {
            get { return _diceTypeList; }
            set { _diceTypeList = value; }
        }


        /// <summary>   
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public  MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            DiceManager = new DiceManager(new List<Dice>()
            {
                new Dice(6),
                new Dice(100),
                new Dice(10),
                new Dice(8),
                new Dice(7)
            });
            //DiceCollectionView = diceManager.DiceView;
            
            DiceManager.DiceSorter.SetSortStrategy(new SortBySides(ListSortDirection.Ascending));

            //AddDiceCommand = new RelayCommand<string>((sides) => Dices.Add(new Dice(int.Parse(sides))));
            ClearDiceCommand = new RelayCommand(() => DiceManager.ClearDices());
            ClacluateDiceCommand = new RelayCommand(RollDices);

            DiceTypeList = new ObservableCollection<DiceCounter>()
            {
                new DiceCounter(2),
                new DiceCounter(4),
                new DiceCounter(6),
                new DiceCounter(8),
                new DiceCounter(10),
                new DiceCounter(20),
                new DiceCounter(100)
            };
            //CalculateDices();
        }

        private async void RollDices()
        {
            await DiceManager.RollAll();
        }

        //public async void CalculateDices()
        //{
        //    System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
           
        //    dispatcherTimer.Tick += async (sender, args) =>
        //    {
        //        Dices = new ObservableCollection<Dice>(await _dataService.GetDices(Dices));
        //    };
        //    dispatcherTimer.Start();
        //    await Task.Delay(500);
        //    dispatcherTimer.Stop();
        //    var diceCollection = await _dataService.GetDices(Dices);
        //    Dices = new ObservableCollection<Dice>(diceCollection);
            
        //}

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}