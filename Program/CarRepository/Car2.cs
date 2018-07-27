using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepository
{
    public partial class Car
    {


        public string Prise
        {
            get
            {
                return _prise.ToString();
            }
            set
            {
                double prise;
                if ((Double.TryParse(value, out prise)))
                {
                    _prise = prise;
                }
                else
                {
                    throw new System.ArgumentException("Value is not double");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _name = value;
                }
            }
        }

        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (value == "")
                {
                    throw new System.ArgumentException("Value can not be null");
                }
                else
                {
                    _color = value;
                }

            }
        }




        public void Discount(int discount = 10)
        {
            this.Disc(discount);
        }

    }
}
