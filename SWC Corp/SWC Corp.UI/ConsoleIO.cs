using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Orders> orders, string date)
        {
            //Grabbing string date and converting it into a readable date. (EX: 01/01/2000)
            string Fus = date.Substring(7);
            string Ro = Fus.Remove(8);
            string Im = Ro.Remove(2);
            string Sorry = Ro.Substring(4);
            string why = Ro.Substring(2);
            string So = why.Remove(2);

            foreach (Orders order in orders)
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine($"Order Number: {order.OrderNumber} | Order Date: {Im}/{So}/{Sorry}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Product Type: {order.ProductType}");
                Console.WriteLine($"Material Cost: {order.MaterialCost:c}");
                Console.WriteLine($"Labor Cost: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine("-------------------------------------------------------------");
            }

        }

        internal static string ValidateStateFormat(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);
                var userInput = Console.ReadLine();


                if (userInput.ToUpper().Length >= 3)
                {
                    Console.WriteLine("States must be abbreviated!");
                }
                else
                {
                    return userInput.ToUpper();
                }

            } while (true);

        }

        internal static decimal ValidateAreaFormat(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);

                var userInput = Console.ReadLine();

                bool successfulParse = decimal.TryParse(userInput, out decimal area);

                if (successfulParse == false)
                {
                    Console.WriteLine("User input was in an incorrect format.");
                }
                if (area < 100)
                {
                    Console.WriteLine("Minimum area is 100");
                }
                else
                {
                    return area;
                }
            } while (true);
        }

        public static void DisplayProducts(List<Products> products)
        {
            foreach (Products product in products)
            {
                Console.WriteLine($"{product.ProductsType}");
            }
        }

        public static void DisplayStateAbbreviation(List<Taxes> taxes)
        {
            foreach (Taxes tax in taxes)
            {
                Console.WriteLine($"{tax.StateAbbreviation}");
            }
        }

        public static string UserDateValidateToString(string date)
        {
            string dateTimeFormated;
            DateTime dateTime;

            string format = "MMddyyyy";



            bool successfulParse = DateTime.TryParse(date, CultureInfo.GetCultureInfo("en-us"), DateTimeStyles.NoCurrentDateDefault, out dateTime);

            if (successfulParse == false)
            {
                Console.WriteLine("Error: Input was not valid.");

            }

            dateTimeFormated = dateTime.ToString(format);


            return $"Orders_{dateTimeFormated}.txt";


        }

        public static DateTime UserDateToDateTime(string date)
        {

            DateTime dateTime;


            bool successfulParse = DateTime.TryParse(date, CultureInfo.GetCultureInfo("en-us"), DateTimeStyles.NoCurrentDateDefault, out dateTime);

            if (successfulParse == false)
            {
                Console.WriteLine("Error: Input was not valid");
                return dateTime;
            }
            else
            {

                return dateTime;
            }

        }

        public static string ValidateCompanyName(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);

                var userNameInput = Console.ReadLine();

                bool results = userNameInput.All(n => Char.IsLetterOrDigit(n) || n == ',' || n == '.' || n == ' ');

                if (results == false)
                {
                    Console.WriteLine("Company name contains an invalid character (Only [A-Z], [0-9], [.], or [,] are acceptable)");
                }
                else
                {
                    return userNameInput;
                }

            } while (true);


        }

        public static bool Exit(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);
                var userConfirm = Console.ReadLine();

                if (userConfirm.ToUpper() == "N")
                {
                    return false;

                }
                else if (userConfirm.ToUpper() == "Y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: Invalid input!");
                }

            } while (true);

        }

        public static int StringToInt(string prompt)
        {
            do
            {
                Console.WriteLine(prompt);

                var userInput = Console.ReadLine();

                int newInt;

                bool successfulParse = int.TryParse(userInput, out newInt);
                if (successfulParse == true)
                {
                    return newInt;
                }
                else
                {
                    Console.WriteLine("That wasn't a number!");
                }

            } while (true);
        }

        public static decimal StringToDecimal(string userInput)
        {

            bool successfulParse = decimal.TryParse(userInput, out decimal newDecimal);
            if (successfulParse == true)
            {
                if (newDecimal < 100)
                {
                    return ValidateAreaFormat("ERROR: Area must be 100 or more. Try again: ");


                }
                else
                {
                    return newDecimal;
                }

            }

            else
            {
                return ValidateAreaFormat("ERROR: Area input was invalid. Try again: ");

            }

        }
    }
}
