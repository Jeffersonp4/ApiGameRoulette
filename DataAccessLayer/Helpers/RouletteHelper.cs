using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helpers
{
    public class RouletteHelper
    {
        public static bool IsEven(int numero)
        {
            return numero != 0 && numero % 2 == 0;
        }

        public static string Getparity(int number)
        {
            if (number != 0) return IsEven(number) ? "Par" : "Impar";
            return "0 es un numero especial";
        }
    }
}
