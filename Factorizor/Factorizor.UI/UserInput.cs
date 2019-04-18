using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInput
{
    public class Workflow
    {
        public void Run()
        {
            int var = GetNumberFromUser();

            Console.WriteLine($"The factors of {var} are: ");
            int countOfFactors = FactorFinder.GetFactorsCount(var); 
            int[] foundFactors = FactorFinder.GetFactors(countOfFactors, var);

            Console.WriteLine($"{string.Join(", ", foundFactors)}");



            if (PrimeChecker.IsPrimeNumber(var) == true)
            {
                Console.WriteLine($"{var} is PRIME");
            }

            else
            {
                Console.WriteLine($"{var} is NOT PRIME ");
            }

            if (PerfectChecker.GetPerfectNumber(var) == true)
            {
                Console.WriteLine($"{var} is a PERFECT number!");
            }
            else
            {
                Console.WriteLine($"{var} is NOT a PERFECT number!");
            }
            
           

        }

        public static int GetNumberFromUser()
        {

            int output;

            while (true)
            {
                Console.Write("What number would you like to factor? ");
                string input = Console.ReadLine();


                if (int.TryParse(input, out output))
                {
                    return output;
                }

                else
                    Console.WriteLine("That is not a number!");
            }


        }

    }

}
