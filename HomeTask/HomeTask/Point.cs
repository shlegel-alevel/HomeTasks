using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask
{
    struct Point
    {
        public int PointPositionOfX { get; set; }
        public int PointPositionOfY { get; set; }

        public Point(int x, int y)
        {
            PointPositionOfX = x;
            PointPositionOfY = y;
        }

        public void MoveLeft()
        {
            PointPositionOfX--;
        }

        public void MoveRight()
        {
            PointPositionOfX++;

        }

        public void MoveDown()
        {
            PointPositionOfY++;
        }

        public void MoveUp()
        {
            PointPositionOfY--;

        }
    }
}
