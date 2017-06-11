using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoll.Model
{
    public class DiceRoller
    {
        public ObservableCollection<Dice> Dices { get; set; }

        public DiceRoller(ObservableCollection<Dice> dices)
        {
            Dices = dices;
        }

        public Task Roll()
        {
            return Task.Run(() =>
                {
                    foreach (var dice in Dices)
                    {
                        dice.Result = RandomNumberGenerator.GetRandomNumber((byte) dice.DiceSides);
                    }
                    
                }
            );

        }
        public Dice RollDice(Dice dice)
        {
            var diceToUpdate = dice;
            diceToUpdate.Result= RandomNumberGenerator.GetRandomNumber((byte)dice.DiceSides);
            return diceToUpdate;

        }
        //public async Task<IEnumerable<Dice>> Roll()
        //{
        //    return await Task.Run(() => Dices.Select(x => new Dice(x.DiceSides)
        //    {
        //        Result = RandomNumberGenerator.GetRandomNumber((byte)x.DiceSides)
        //    }));

        //}

        private IEnumerable<Dice> RollDices()
        {
            return Dices.Select(x => new Dice(x.DiceSides)
            {
                Result = RandomNumberGenerator.GetRandomNumber((byte)x.DiceSides)
            });
        }



    }
}
