﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceRoll.Model;

namespace DiceRoll.Core.DiceManager.Sort
{
    public class SortBySides : SortStrategy
    {
        private ListSortDirection sortTactic;

        public SortBySides(ListSortDirection tactic)
        {
            sortTactic = tactic;
        }

        public override void Sort(ICollectionView diceCollection)
        {
            
            switch (sortTactic)
            {
                    case ListSortDirection.Ascending:
                        diceCollection.SortDescriptions.Add(new SortDescription("DiceSides", ListSortDirection.Ascending));
                    break;
                    case ListSortDirection.Descending:
                    diceCollection.SortDescriptions.Add(new SortDescription("DiceSides", ListSortDirection.Descending));
                    break;

                    default:
                    diceCollection.SortDescriptions.Add(new SortDescription("DiceSides", ListSortDirection.Ascending));
                    break;
            }

           
        }
    }
}