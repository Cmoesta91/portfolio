using SWC_Corp.BLL;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.UI.Workflow
{
    public class OrderLookupWorkflow
    {

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Lookup an Order");
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter an order date: ");

            string userInput = Console.ReadLine();

            var path = ConsoleIO.UserDateValidateToString(userInput);

            OrderManager manager = OrderManagerFactory.Create(path);

            OrderLookupResponse respose = manager.LookupOrders(path);

            if(respose.Success)
            {
                ConsoleIO.DisplayOrderDetails(respose.orders, ConsoleIO.UserDateValidateToString(userInput));
            }
            else
            {
                Console.WriteLine("An error has occurred: ");
                Console.WriteLine(respose.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();





        }
    }
}
