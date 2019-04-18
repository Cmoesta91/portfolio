using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorFinder
    {

        public static int GetFactorsCount (int num)
        {
            int factorCounter = 0;
            

            for (int factor = 1; factor < num; factor++)
            {
                if (num % factor == 0)
                {
                    factorCounter++;
                }
            }

            return factorCounter;
        }

        public static int[] GetFactors(int factorCount, int input)
        {
            int counter = 0;
            int[] factorarray = new int[factorCount];

            for (int factor = 1; factor < input; factor++)
            {
                if (input % factor == 0)
                {
                    factorarray[counter] = factor;
                    counter++;

                }
            }

            return factorarray;   
        }
    }

}
