using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public class UberCheater : CheaterPlayer
    {
        public override TypeOfPlayer TypeOfPlayer { get; set; }
        public override int StepNumber { get; set; }
        public override string Name { get; set; }
        public override int[] PreviousNumbers { get; set; }

        public UberCheater()
        {
            StepNumber = MinPossibleValue - 1;
            TypeOfPlayer = TypeOfPlayer.UberCheater;
            Name = "Grumpy";
        }

        public UberCheater(string name, int minPossibleValue, int maxPossibleValue) : base(name, minPossibleValue, maxPossibleValue)
        {
            StepNumber = MinPossibleValue - 1;
            TypeOfPlayer = TypeOfPlayer.UberCheater;
            Name = name;
        }

        public override int PostNumber(int[] usedNumbers)
        {
            do
            {
                StepNumber++;
            }
            while (IfNumberWasPostBefore(StepNumber, usedNumbers));

            ExpandPreviousNumbersArray(StepNumber);

            return StepNumber;
        }

    }
}
