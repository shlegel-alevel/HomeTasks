using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public partial class Car
    {
        private double _prise;
        private string _name;
        private string _color;

        private void Disc(int discount)
        {
            _prise = _prise - (_prise * discount / 100);
        }
    }
}
