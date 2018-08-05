using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public abstract class Player
    {

        public abstract int StepNumber { get; set; }
        public abstract TypeOfPlayer TypeOfPlayer { get; set; }
        public abstract string Name { get; set; }
        public virtual int[] PreviousNumbers { get; set; }

        public int MinPossibleValue { get; set; }
        public int MaxPossibleValue { get; set; }

        public Player ()
        {
            MinPossibleValue = 40;
            MaxPossibleValue = 140;
        }

        public Player(int minPossibleValue, int maxPossibleValue)
        {
            MinPossibleValue = minPossibleValue;
            MaxPossibleValue = maxPossibleValue;
        }

        public Player(string name, int minPossibleValue=40, int maxPossibleValue=140)
        {
            MinPossibleValue = minPossibleValue;
            MaxPossibleValue = maxPossibleValue;
            Name = name;
        }

        public virtual int PostNumber()
        {
            Random rnd = new Random();
            StepNumber = rnd.Next(MinPossibleValue,MaxPossibleValue);
            return StepNumber;
        }

        public virtual int PostNumber(int[] usedNumbers)
        {
            PostNumber();
            return StepNumber;
        }
    }
}

