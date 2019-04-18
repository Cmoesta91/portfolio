using SWC_Corp.BLL;
using SWC_Corp.BLL.RulesForOrders;
using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.UI.Workflow
{
    public class NewOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();

            IFileOrderRepo fileOrderRepo;
            Orders newOrder = new Orders();
            Products products = new Products();

            Console.WriteLine("New Order Form");
            Console.WriteLine("----------------------");

            Console.WriteLine("Enter a date (New orders must be set in future dates): ");
            var userInput = Console.ReadLine();
            var path = ConsoleIO.UserDateValidateToString(userInput);
            var userDate = ConsoleIO.UserDateToDateTime(userInput);

            newOrder.CustomerName = ConsoleIO.ValidateCompanyName("Enter company name: ");

            ConsoleIO.DisplayStateAbbreviation(FileTaxRepo.LoadTaxes());
            newOrder.State = ConsoleIO.ValidateStateFormat("Enter a State: (States must be abbreviated)");

            Console.WriteLine("Select A Product: ");
            ConsoleIO.DisplayProducts(FileProductsRepo.LoadProducts());
            newOrder.ProductType = Console.ReadLine();

            newOrder.Area = ConsoleIO.ValidateAreaFormat("What's the Area? (Must be minimum of 100 square feet): ");

            NewOrderResponse response = new NewOrderResponse();
            response = NewOrderRules.NewOrder(userDate, newOrder.State, newOrder.ProductType);

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

                ConsoleIO.DisplayOrderDetails(new List<Orders> { newOrder }, path);


                if (ConsoleIO.Exit("Do you want to SAVE new order? [Y/N]") == false)
                {
                    return;
                }
                else
                {

                    fileOrderRepo = new FileOrderRepo(path);

                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                        fileOrderRepo.Create(newOrder);
                    }
                    else
                    {
                        fileOrderRepo.Create(newOrder);

                    }
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

        }
    }
}
