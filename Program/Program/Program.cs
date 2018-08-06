using System;
using System.Threading;
using Game;
using PlayersLogic;


namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;

            Console.SetWindowSize(140, Console.WindowHeight);
            do
            {
                StartMenu();
                GameClass game;
                switch (Console.ReadLine())
                {
                    case "1":
                        game=DefaultGame();
                        LogicOfGameAndOut(game);
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                    case "2":
                        game = NonDefaultGame();
                        LogicOfGameAndOut(game);
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                    case "3":
                        exit = false;
                        break;
                    default:
                        ErrorMessage("Invalid. You should enter only [1], [2], [3]");
                        NavigateToBackMessage("Please press any button to continue");
                        break;
                }

            }
            while (exit);
        }

        private static GameClass DefaultGame()
        {
            GameClass game = new GameClass();
            return game;
        }

        private static GameClass NonDefaultGame()
        {
            int numberOfPlayers, minValueOfBasket, maxValueOfBasket;
            numberOfPlayers = EnterNumberOfPLayers("Please enter number of players from 2 to 8: ", "Invalid. You should enter only digits from 2 till 8");
            minValueOfBasket = EnterMinValueOfPossibleNumbers("Please enter min value for basket: ", "Invalid. You should enter only numbers");
            maxValueOfBasket = EnterMaxValueOfPossibleNumbers("Please enter max value for basket: ", "Invalid. You should enter only numbers and max value should be more than min value", minValueOfBasket);
            EnterTypeOfPlayers(numberOfPlayers, out var typeOfPlayers, out var nameOfPlayers);
            GameClass game = new GameClass(minValueOfBasket, maxValueOfBasket, typeOfPlayers, nameOfPlayers);

            return game;
        }

        private static void LogicOfGameAndOut (GameClass game)
        {
            Console.WriteLine("Game will start in a few minutes. Please wait a little bit...");
            string[] uiMessages = new string[game.MaxCountOfAttempts];
            game.GameRounds(out uiMessages);
            Console.WriteLine();
            Console.Write($"Let's get started. The basket weight is {game.BasketWeight}");
            Console.WriteLine();
            for (int i = 0; i < uiMessages.Length; i++)
            {
                if (uiMessages[i] != null)
                {
                    Thread.Sleep(100);
                    Console.WriteLine(uiMessages[i]);
                }
            }
        }

        private static int EnterMaxValueOfPossibleNumbers(string message, string errorMessage, int minValue)
        {
            var exit = true;
            var maxValue = 0;
            do
            {
                Console.Write(message);
                var result = Int32.TryParse(Console.ReadLine(), out maxValue);
                if ((result == true) && (maxValue > minValue))
                {
                    exit = false;
                }
                else
                {
                    ErrorMessage(errorMessage);
                }
            }
            while (exit);
            return maxValue;
        }

        private static int EnterMinValueOfPossibleNumbers(string message, string errorMessage)
        {
            var exit = true;
            var minValue = 0;
            do
            {
                Console.Write(message);
                var result = Int32.TryParse(Console.ReadLine(), out minValue);
                if ((result == true) && (minValue > 0))
                {
                    exit = false;
                }
                else
                {
                    ErrorMessage(errorMessage);
                }
            }
            while (exit);
            return minValue;
        }

        private static int EnterNumberOfPLayers (string message, string errorMessage)
        {
            var exit = true;
            var numberOfPlayers = 0;
            do
            {
                Console.Write(message);
                var result = Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
                if ((result == true) && (numberOfPlayers > 1) && (numberOfPlayers <= 8))
                {
                    exit = false;
                }
                else
                {
                    ErrorMessage(errorMessage);
                }
            }
            while (exit);

            return numberOfPlayers;
        }

        private static void EnterTypeOfPlayers (int numberOfPlayers, out TypeOfPlayer[] typeOfPlayers, out string[] nameOfPlayers)
        {
            typeOfPlayers = new TypeOfPlayer [numberOfPlayers];
            nameOfPlayers = new string [numberOfPlayers];
            ConsoleKeyInfo key;
            var exit = true;
            do
            {
                for (int i = 0; i< numberOfPlayers; i++)
                {
                    Console.Write ($"Please select type of player {i+1}: [u]-UsualPlayer (default), [n]-NotePadPlayer, [b]-UberPlayer, [c]-CheaterPlayer, [a]-UberCheater: ");
                    key = Console.ReadKey();
                    Console.WriteLine();
                    switch (key.Key)
                    {
                        case ConsoleKey.U:
                            typeOfPlayers[i] = TypeOfPlayer.UsualPlayer;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                        case ConsoleKey.N:
                            typeOfPlayers[i] = TypeOfPlayer.NotePadPlayer;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                        case ConsoleKey.B:
                            typeOfPlayers[i] = TypeOfPlayer.UberPlayer;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                        case ConsoleKey.C:
                            typeOfPlayers[i] = TypeOfPlayer.CheaterPlayer;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                        case ConsoleKey.A:
                            typeOfPlayers[i] = TypeOfPlayer.UberCheater;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                        default:
                            typeOfPlayers[i] = TypeOfPlayer.UsualPlayer;
                            Console.Write($"Please enter Name of player {i + 1}:");
                            nameOfPlayers[i] = Console.ReadLine();
                            break;
                    }
                    Console.WriteLine($"Your player {i + 1} is {typeOfPlayers[i]} with name: {nameOfPlayers[i]}");
                }
                exit = false;
            }
            while (exit);
        }

        private static void StartMenu ()
        {
            Console.WriteLine("Welcome to basket game");
            Console.WriteLine("What would you like to do: ");
            Console.WriteLine("Enter [1] to start game with default settings: 5 players, weight is random value from 40 to 140 and 100 attempts maximum");
            Console.WriteLine("Enter [2] to start game with custom settings");
            Console.WriteLine("Enter [3] to exit");
            Console.Write("Please make your choise: ");
        }

        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void NavigateToBackMessage(string message)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }

    }
}
