using System;
using PlayersLogic;
using System.Threading;

namespace Game
{
    public class GameClass
    {
        public int MinPossibleValue { get; set; }
        public int MaxPossibleValue { get; set; }
        public int BasketWeight { get; set; }
        public Player[] Players { get; set; }
        public int MaxCountOfAttempts { get; set; }
        public static int DefaultNumberOfPlayers {get; set;}
        public static int [] UsedNumbers { get; set; }
        private static string _closingUser;
        private static int _valueForNumberOfClosingUser;

        static GameClass()
        {
            DefaultNumberOfPlayers = 5;
            UsedNumbers = new int[0];
            _closingUser = "";
            _valueForNumberOfClosingUser = 0;
        }

        public GameClass()
        {
            MinPossibleValue = 40;
            MaxPossibleValue = 140;
            InitializeDefaultPlayers();
            MaxCountOfAttempts = MaxPossibleValue - MinPossibleValue;
            Random rng = new Random();
            BasketWeight = rng.Next(MinPossibleValue, MaxPossibleValue);
            _valueForNumberOfClosingUser = MaxPossibleValue;
        }

        public GameClass(int minPossibleVale, int maxPossibleValue, TypeOfPlayer [] typeOfPlayers, string [] namesOfPlayers)
        {
            MinPossibleValue = minPossibleVale;
            MaxPossibleValue = maxPossibleValue;
            _valueForNumberOfClosingUser = MaxPossibleValue;
            MaxCountOfAttempts = maxPossibleValue- minPossibleVale;
            Random rng = new Random();
            BasketWeight = rng.Next(MinPossibleValue, MaxPossibleValue);
            Players = new Player[typeOfPlayers.Length];
            for (int i=0; i<typeOfPlayers.Length; i++)
            {
                switch (typeOfPlayers[i])
                {
                 case TypeOfPlayer.UsualPlayer:
                        Players[i]= new UsualPlayer(namesOfPlayers[i], MinPossibleValue, MaxPossibleValue);
                        break;
                 case TypeOfPlayer.NotePadPlayer:
                        Players[i] = new NotePadPlayer(namesOfPlayers[i], MinPossibleValue, MaxPossibleValue);
                        break;
                 case TypeOfPlayer.UberPlayer:
                        Players[i] = new UberPlayer(namesOfPlayers[i], MinPossibleValue, MaxPossibleValue);
                        break;
                 case TypeOfPlayer.CheaterPlayer:
                        Players[i] = new CheaterPlayer(namesOfPlayers[i], MinPossibleValue, MaxPossibleValue);
                        break;
                 case TypeOfPlayer.UberCheater:
                        Players[i] = new UberCheater(namesOfPlayers[i], MinPossibleValue, MaxPossibleValue);
                        break;
                }
            }

        }

        private void InitializeDefaultPlayers ()
        {
            Players = new Player[DefaultNumberOfPlayers];
            Players[0] = new UsualPlayer();
            Players[1] = new NotePadPlayer();
            Players[2] = new UberPlayer();
            Players[3] = new UberCheater();
            Players[4] = new CheaterPlayer();
        }

        public void GameRounds (out string [] uiMessages)
        {
            uiMessages = new string[MaxCountOfAttempts+1];
            var numberOfAttempt = 0;
            var currentStep = 0;
            var Counter = 0;
            var exit = true;
            var indexOfCheaters = GetIndexOfCheaters();

            do
            {
                for (int i=0; i<Players.Length; i++)
                {
                    Thread.Sleep(50);
                    if ((Players[i].TypeOfPlayer == TypeOfPlayer.CheaterPlayer)||(Players[i].TypeOfPlayer == TypeOfPlayer.UberCheater))
                    {
                        currentStep = Players[i].PostNumber(UsedNumbers);
                    }
                    else
                    {
                        currentStep = Players[i].PostNumber();
                    }
                    ExpandUsedNumbersArray(currentStep);
                    CheckingClosingUsers(Players[i], currentStep, _valueForNumberOfClosingUser);
                    uiMessages[Counter] = $"Attempt {++numberOfAttempt}: {Players[i].TypeOfPlayer} with name {Players[i].Name} has made his choise: {currentStep}";

                    Counter++;
                    if (currentStep == BasketWeight)
                    {
                        uiMessages[Counter] = $"Game is finished on the round {numberOfAttempt}: The winner is {Players[i].TypeOfPlayer} with name {Players[i].Name}: {currentStep}";
                        exit = false;
                        break;
                    }
                    else if (numberOfAttempt == MaxCountOfAttempts)
                    {
                        uiMessages[Counter] = $"There is not any winner after max atempts: {MaxCountOfAttempts}. The first the most closed value was from user: {_closingUser}";
                        exit = false;
                        break;
                    }
                }
            }
            while (exit);
        }

        private void ExpandUsedNumbersArray(int stepNumber)
        {
            int[] tempUsedNumbers = new int[UsedNumbers.Length + 1];
            Array.Copy(UsedNumbers, tempUsedNumbers, UsedNumbers.Length);
            tempUsedNumbers[tempUsedNumbers.Length - 1] = stepNumber;
            UsedNumbers = new int[tempUsedNumbers.Length];
            Array.Copy(tempUsedNumbers, UsedNumbers, UsedNumbers.Length);
        }

        private int GetIndexOfCheaters ()
        {
            int index=0;
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].TypeOfPlayer==TypeOfPlayer.CheaterPlayer)
                {
                    index = i;
                }
            }
            return index;
        }

        private string CheckingClosingUsers (Player player, int currentstep, int temp)
        {

            if (Math.Abs(BasketWeight - currentstep) < temp)
            {
                _closingUser = $"{player.TypeOfPlayer} with name {player.Name} and value: {currentstep}";
                _valueForNumberOfClosingUser = Math.Abs(BasketWeight - currentstep);
            }

            return _closingUser;
        }

    }
}
