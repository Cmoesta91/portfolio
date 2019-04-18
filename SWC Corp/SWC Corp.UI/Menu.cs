using SWC_Corp.UI.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Crop.Models
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SWC Corp Flooring");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1) Display Orders");
                Console.WriteLine("2) Add An Order");
                Console.WriteLine("3) Edit An Order");
                Console.WriteLine("4) Remove An Order");
                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch(userinput.ToUpper())
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        NewOrderWorkflow newOrderWorkflow = new NewOrderWorkflow();
                        newOrderWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Execute();
                        break;
                    case "Q":
                        return;

                }

            }

        }
    }
}
