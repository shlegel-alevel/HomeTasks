using System;
using CarRepository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfCar = 3;

            Car[] cars = new Car[countOfCar];
            bool exit = true;
            int i = 0;

            do
            {
                try
                {
                    for (; i < cars.Length;)
                    {
                        cars[i] = CreateNewCar(i+1);
                        i++;
                    }
                    exit = false;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine();
                    Console.WriteLine(ae.Message);
                    Console.WriteLine("Please press any button to start from beginning");
                    Console.ReadLine();
                }
            }
            while (exit);

            MakeDiscount(cars);
            exit = true;

            do
            {
                Console.Write("Please enter keys [1], [2], [3] to see car details:");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        ShowCarDetail(cars[0]);
                        break;
                    case ConsoleKey.D2:
                        ShowCarDetail(cars[1]);
                        break;
                    case ConsoleKey.D3:
                        ShowCarDetail(cars[2]);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Incorrect symbols");
                        break;
                }
            }
            while (exit);

            Console.ReadLine();

        }


        public static void ShowCarDetail(Car car)
        {
            Console.WriteLine();
            Console.WriteLine($"Car with name: {car.Name}; color: {car.Color}, prise: {car.Prise}");
            Console.WriteLine();
        }

        public static Car CreateNewCar(int carCounter)
        {

        Car car = new Car();
        Console.WriteLine();
        Console.Write($"Please enter name of car {carCounter}: ");
        car.Name = Console.ReadLine();
        Console.Write($"Please enter color of car {carCounter} with name {car.Name}: ");
        car.Color = Console.ReadLine();
        Console.Write($"Please enter prise of car {carCounter} with name {car.Name}: ");
        car.Prise = Console.ReadLine();

        return car;
        }

        public static Car[] MakeDiscount (Car [] cars)
        {
            for (int i=0; i < cars.Length;i++)
            {
                cars[i].Discount();
            }
            return cars;
        }

    }
}
