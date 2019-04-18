using SWC_Corp.BLL;
using SWC_Corp.BLL.RulesForOrders;
using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.UI.Workflow
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            IFileOrderRepo fileOrderRepo;
            Orders newOrder = new Orders();

            Console.WriteLine("Edit Order Form");
            Console.WriteLine("--------------------------");

            Console.WriteLine("Enter a date: ");

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

            int orderNumber = ConsoleIO.StringToInt("Which order would you like to edit? (Choose order by it's ORDER NUMBER): ");

            Console.Clear();

            fileOrderRepo = new FileOrderRepo(path);
            fileOrderRepo.LoadOrder();

            Orders oldOrder = fileOrderRepo.ReadByOrderNumber(orderNumber);

            ConsoleIO.DisplayOrderDetails(new List<Orders> { oldOrder }, path);

            string newName = ConsoleIO.ValidateCompanyName("Enter new NAME or hit enter to continue: ");

            if(string.IsNullOrEmpty(newName) )
            {
                newOrder.CustomerName = oldOrder.CustomerName;
            }
            else
            {
                newOrder.CustomerName = newName;
            }

            ConsoleIO.DisplayStateAbbreviation(FileTaxRepo.LoadTaxes());
            Console.WriteLine("Enter new STATE or hit enter to continue:");
            Console.WriteLine("REMINDER: States MUST be abbreviated!!");
            string newState = Console.ReadLine();
            if(string.IsNullOrEmpty(newState))
            {
                newOrder.State = oldOrder.State;
            }
            else
            {
                newOrder.State = newState;
            }

            ConsoleIO.DisplayProducts(FileProductsRepo.LoadProducts());
            Console.WriteLine("Enter new PRODUCT TYPE or hit enter to continue:");
            string newProduct = Console.ReadLine();
            if(string.IsNullOrEmpty(newProduct))
            {
                newOrder.ProductType = oldOrder.ProductType;
            }
            else
            {
                newOrder.ProductType = newProduct;
            }

            Console.WriteLine("Enter new AREA or hit enter to continue:");
            Console.WriteLine("REMINDER: Area MUST be at minimum 100");
            string newArea = Console.ReadLine();
            if(string.IsNullOrEmpty(newArea))
            {
                newOrder.Area = oldOrder.Area;
            }
            else
            {
                newOrder.Area = ConsoleIO.StringToDecimal(newArea);
            }

            DateTime.TryParse(userInputDate, CultureInfo.GetCultureInfo("en-us"), DateTimeStyles.NoCurrentDateDefault, out DateTime dateTime);

            NewOrderResponse response = new NewOrderResponse();
            response = NewOrderRules.NewOrder(dateTime, newOrder.State, newOrder.ProductType);

            if (response.Success == false)
            {
                Console.WriteLine(response.Message);
                Console.ReadKey();

            }
            else
            {
                newOrder.TaxRate = response.Tax;
                newOrder.CostPerSquareFoot = response.CostPerSquareFoot;
                newOrder.LaborCostPerSquareFoot = response.LaborCostPerSquareFoot;
                newOrder.OrderNumber = response.OrderNumber;

                Console.Clear();

                Console.WriteLine("Summary");
                Console.WriteLine("-------------------------------------------------------------");

                Console.WriteLine("OLD ORDER");
                Console.WriteLine("*************************************************************");
                ConsoleIO.DisplayOrderDetails(new List<Orders> { oldOrder }, path);
                Console.WriteLine("*************************************************************");

                Console.WriteLine("NEW ORDER");
                Console.WriteLine("-------------------------------------------------------------");
                ConsoleIO.DisplayOrderDetails(new List<Orders> { newOrder }, path);
                Console.WriteLine("-------------------------------------------------------------");

                if (ConsoleIO.Exit("Do you want to SAVE edited order? [Y/N]") == false)
                {
                    return;
                }
                else
                {

                    fileOrderRepo.Delete(oldOrder.OrderNumber, oldOrder);

                    fileOrderRepo.Create(newOrder);
                }

            }


            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}
