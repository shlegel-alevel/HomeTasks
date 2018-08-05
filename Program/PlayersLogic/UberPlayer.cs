using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public class UberPlayer : Player
    {
        public override TypeOfPlayer TypeOfPlayer { get; set; }
        public override int StepNumber { get; set; }
        public override string Name { get; set; }

        public UberPlayer ()
        {
            StepNumber = MinPossibleValue-1;
            TypeOfPlayer = TypeOfPlayer.UberPlayer;
            Name = "Bashful";
        }

        public UberPlayer(string name, int minPossibleValue, int maxPossibleValue) : base(name, minPossibleValue, maxPossibleValue)
        {
            StepNumber = MinPossibleValue - 1;
            TypeOfPlayer = TypeOfPlayer.UberPlayer;
            Name = name;
        }

        public override int PostNumber()
        {
            StepNumber ++;
            if (StepNumber == MaxPossibleValue)
            {
                StepNumber = base.MinPossibleValue;
            }

            return StepNumber;
        }
    }
}
