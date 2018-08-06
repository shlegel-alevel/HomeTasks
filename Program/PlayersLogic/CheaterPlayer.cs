using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public class CheaterPlayer : NotePadPlayer
    {
        public override TypeOfPlayer TypeOfPlayer { get; set; }
        public override int StepNumber { get; set; }
        public override string Name { get; set; }
        public override int[] PreviousNumbers { get; set; }

        public CheaterPlayer()
        {
            TypeOfPlayer = TypeOfPlayer.CheaterPlayer;
            Name = "Doc";
        }

        public CheaterPlayer(string name, int minPossibleValue, int maxPossibleValue) : base(name, minPossibleValue, maxPossibleValue)
        {
            TypeOfPlayer = TypeOfPlayer.CheaterPlayer;
            Name = name;
        }

        public override int PostNumber(int [] usedNumbers)
        {
            do
            {
                base.PostNumber(usedNumbers);
            }
            while (IfNumberWasPostBefore(StepNumber, usedNumbers));

            ExpandPreviousNumbersArray(StepNumber);

            return StepNumber;
        }

        protected override bool IfNumberWasPostBefore(int stepNumber, int[] previousNumbers)
        {
            bool ifNumberWasPostBefore = false;

            for (int i = 0; i < previousNumbers.Length; i++)
            {
                if (StepNumber == previousNumbers [i])
                {
                    ifNumberWasPostBefore = true;
                }
            }
            return ifNumberWasPostBefore;
        }

    }
}
