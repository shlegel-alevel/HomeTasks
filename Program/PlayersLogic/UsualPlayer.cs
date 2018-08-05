using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersLogic
{
    public class UsualPlayer : Player
    {
        public override TypeOfPlayer TypeOfPlayer { get; set; }
        public override int StepNumber { get; set; }
        public override string Name { get; set; }

        public UsualPlayer ()
        {
            TypeOfPlayer = TypeOfPlayer.UsualPlayer;
            Name = "Dopey";
        }

        public UsualPlayer(string name, int minPossibleValue, int maxPossibleValue):base (name, minPossibleValue, maxPossibleValue)
        {
            TypeOfPlayer = TypeOfPlayer.UsualPlayer;
            Name = name;
        }
    }
}
