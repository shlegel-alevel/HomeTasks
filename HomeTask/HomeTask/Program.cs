using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    class Program

    {
        static void Main(string[] args)

        {

            int countOfClicks = 1;
            int size = 15;
            int keyckicks = 0;

            Point cursor = new Point(size - 2, size - 2);

            Random rdm = new Random();

            Point[] figures = new Point[1];

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i] = RandomNumberInitialization(size, rdm);
            }

            DrawSquare(ArrayInitialization(size, cursor, figures), size);

            bool exit = true;

            do
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.Clear();
                        cursor = MoveLeft(cursor, size);
                        keyckicks++;
                        figures = UIDraw(figures, keyckicks, cursor, size, out exit, countOfClicks);

                        break;

                    case ConsoleKey.RightArrow:
                        Console.Clear();
                        cursor = MoveRight(cursor, size);
                        keyckicks++;
                        figures = UIDraw(figures, keyckicks, cursor, size, out exit, countOfClicks);

                        break;

                    default:
                        break;
                }
            } while (exit);



            Console.ReadLine();
        }


        public static Point[] UIDraw(Point[] figures, int keyckicks, Point cursor, int size, out bool exit, int countOfClicks)
        {
            bool fail;
            exit = true;

            figures = MoveDown(figures, cursor, size, out fail);
            figures = FiguresInitialization(figures, keyckicks, size, countOfClicks);
            DrawSquare(ArrayInitialization(size, cursor, figures), size);

            if (fail == true)
            {
                exit = false;
                Console.WriteLine("Game over. Please press any button to exit");
            }

            return figures;
        }


        public static Point RandomNumberInitialization(int size, Random rdm)
        {

            Point randomNumber = new Point(rdm.Next(1, size - 1), 1);

            return randomNumber;
        }


        public static Point[] FiguresInitialization(Point[] figures, int keyckicks, int size, int countOfClicks)
        {
            Point[] updfigures;
            Random rdm = new Random();

            if (keyckicks % countOfClicks == 0)
            {
                updfigures = new Point[figures.Length + 1];
                Array.Copy(figures, updfigures, figures.Length);
                updfigures[updfigures.Length - 1] = RandomNumberInitialization(size, rdm);
                return updfigures;
            }
            else
            {
                return figures;
            }
        }


        public static void DrawSquare(string[,] square, int size)
        {
            for (int line = 0; line < size; line++)
            {
                for (int lineStep = 0; lineStep < size; lineStep++)
                {
                    Console.Write(square[line, lineStep]);
                }
                Console.WriteLine();
            }
        }


        public static string[,] ArrayInitialization(int size, Point cursor, Point[] figures)
        {
            string[,] square = new string[size, size];


            for (int line = 0; line < size; line++)
            {
                for (int lineStep = 0; lineStep < size; lineStep++)
                {
                    if ((line == 0) || (line == size - 1))
                    {
                        square[line, lineStep] = ". ";
                    }
                    else if ((lineStep == 0) || (lineStep == size - 1))
                    {
                        square[line, lineStep] = ". ";
                    }
                    else if ((cursor.PointPositionOfX == lineStep) && (cursor.PointPositionOfY == line))
                    {
                        square[line, lineStep] = "__";
                    }
                    else
                    {
                        square[line, lineStep] = "  ";
                    }

                    for (int i = 0; i < figures.Length; i++)
                    {
                        if ((figures[i].PointPositionOfX == lineStep) && (figures[i].PointPositionOfY == line))
                        {
                            square[line, lineStep] = "■■";
                            if ((figures[i].PointPositionOfX == cursor.PointPositionOfX) && (figures[i].PointPositionOfY == cursor.PointPositionOfY))
                            {
                                square[line, lineStep] = "ff";
                            }
                        }

                    }


                }
            }
            return square;
        }


        public static Point MoveLeft(Point cursor, int size)
        {
            cursor.MoveLeft();
            if (cursor.PointPositionOfX <= 0)
            {
                cursor.PointPositionOfX = size - 2;
            }

            return cursor;
        }


        public static Point MoveRight(Point cursor, int size)
        {
            cursor.MoveRight();
            if (cursor.PointPositionOfX >= size - 1)
            {
                cursor.PointPositionOfX = 1;
            }
            return cursor;
        }


        public static Point[] MoveDown(Point[] figures, Point cursor, int size, out bool fail)
        {
            fail = false;

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].MoveDown();

                if ((figures[i].PointPositionOfY == cursor.PointPositionOfY) && (figures[i].PointPositionOfX == cursor.PointPositionOfX))
                {
                    fail = true;
                }

                if (figures[i].PointPositionOfY == size - 1)
                {
                    figures = DeletingFigure(figures, i);
                    i--;
                }

            }

            return figures;
        }



        public static Point[] DeletingFigure(Point[] figures, int position)
        {
            Point[] updFigures = new Point[figures.Length - 1];

            Array.Copy(figures, position + 1, updFigures, 0, updFigures.Length);


            figures = new Point[updFigures.Length];

            Array.Copy(updFigures, figures, figures.Length);

            return figures;
        }

    }
}
