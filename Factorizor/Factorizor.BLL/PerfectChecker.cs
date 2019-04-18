using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class PerfectChecker
    {
       public static bool GetPerfectNumber(int num)
        {
            int sumeOfFactors = 0;
            
            for (int factor = 1; factor < num; factor++)
            {
                if (num % factor == 0)
                {
                    sumeOfFactors = sumeOfFactors + factor; 
                }
            }

            if (sumeOfFactors == num)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}
