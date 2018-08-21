using System;
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
            try
            {
                string[] array = { "(", "(", ")", ")" };

                Console.WriteLine(IfMassiveIsValid(array));

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            Console.ReadLine();

        }


        private static bool IfMassiveIsValid (string [] array)
        {
            var result = true;
            var counter=0;
            for (int i=0; i<array.Length; i++)
            {
                if (array[i] == "(")
                    counter++;
                else if (array[i] == ")")
                     counter--;
                else 
                throw new ArgumentException ("Incorect symbols");
                if (counter <0)
                {
                    result = false;
                    break;
                }
            }
            if (counter != 0)
                result = false;
            return result;
        }
    }
}
