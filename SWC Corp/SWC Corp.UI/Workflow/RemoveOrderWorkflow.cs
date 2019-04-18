using SWC_Corp.BLL;
using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.UI.Workflow
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            IFileOrderRepo fileOrderRepo;
            Console.WriteLine("Remove an Order");
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter an order date: ");

            string userInputDate = Console.ReadLine();

            if (string.IsNullOrEmpty(userInputDate))
            {
                Console.WriteLine("Error: User input was invalid...Hit any key to return to menu...");
                Console.ReadKey();
                return;
            }

            var path = ConsoleIO.UserDateValidateToString(userInputDate);

            OrderManager manager = OrderManagerFactory.Create(path);

            OrderLookupResponse respose = manager.LookupOrders(path);

            if (respose.Success)
            {
                ConsoleIO.DisplayOrderDetails(respose.orders, path);
            }
            else
            {
                Console.WriteLine("An error has occurred: ");
                Console.WriteLine(respose.Message);
            }

            int orderNumber = ConsoleIO.StringToInt("Which order would you like to remove? (Choose order by it's ORDER NUMBER): ");

            Console.Clear();

            fileOrderRepo = new FileOrderRepo(path);
            fileOrderRepo.LoadOrder();

            Orders Order = fileOrderRepo.ReadByOrderNumber(orderNumber);

            ConsoleIO.DisplayOrderDetails(new List<Orders> { Order }, path);

            if(ConsoleIO.Exit("Do you want to DELETE order? [Y/N]") == false)
            {
                return;
            }
            else
            {
                fileOrderRepo.Delete(Order.OrderNumber, Order);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
