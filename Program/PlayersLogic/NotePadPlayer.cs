using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public class NotePadPlayer: Player
    {
        public override TypeOfPlayer TypeOfPlayer { get; set; }
        public override int StepNumber { get; set; }
        public override string Name { get; set; }

        public override int[] PreviousNumbers { get; set; }

        public NotePadPlayer()
        {
            PreviousNumbers = new int[0];
            TypeOfPlayer = TypeOfPlayer.NotePadPlayer;
            Name = "Happy";
        }

        public NotePadPlayer (string name, int minPossibleValue, int maxPossibleValue) : base(name, minPossibleValue, maxPossibleValue)
        {
            PreviousNumbers = new int[0];
            TypeOfPlayer = TypeOfPlayer.NotePadPlayer;
            Name = name;
        }

        public override int PostNumber()
        {
            do
            {
                base.PostNumber();
            }
            while (IfNumberWasPostBefore(StepNumber, PreviousNumbers));

            ExpandPreviousNumbersArray(StepNumber);

            return StepNumber;
        }

        protected virtual bool IfNumberWasPostBefore (int stepNumber, int [] previousNumbers)
        {
            bool ifNumberWasPostBefore = false;

            for (int i = 0; i < previousNumbers.Length; i++)
            {
                if (StepNumber == PreviousNumbers[i])
                {
                    ifNumberWasPostBefore = true;
                }
            }
            return ifNumberWasPostBefore;
        }

        protected void ExpandPreviousNumbersArray (int stepNumber)
        {
            int[] tempPreviousNumbers = new int[PreviousNumbers.Length + 1];
            Array.Copy(PreviousNumbers, tempPreviousNumbers, PreviousNumbers.Length);
            tempPreviousNumbers[tempPreviousNumbers.Length - 1] = stepNumber;
            PreviousNumbers = new int[tempPreviousNumbers.Length];
            Array.Copy(tempPreviousNumbers, PreviousNumbers, PreviousNumbers.Length);
        }

    }
}
