using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.BLL.RulesForOrders
{
    public static class NewOrderRules
    {
       
       
        public static NewOrderResponse NewOrder(DateTime dateTime, string state, string productType)
        {
            NewOrderResponse response = new NewOrderResponse();
            IFileOrderRepo orderRepo = new FileOrderRepo(dateTime.Day.ToString() + dateTime.Month.ToString() + dateTime.Year.ToString());
            List<Taxes> taxes = FileTaxRepo.LoadTaxes();
            List<Products> products = FileProductsRepo.LoadProducts();
            
            if (dateTime <= DateTime.Now)
            {
                response.Success = false;
                response.Message = "Error: New Orders must be set in the future";
                return response;
            }

            bool stateVerification = taxes.Any(t => state.Contains(t.StateAbbreviation));
            if (stateVerification == false)
            {
                response.Success = false;
                response.Message = "Error: We do not sell in inputed state";
                return response;
            }

            bool productVerification = products.Any(p => productType.Contains(p.ProductsType));
            if (productVerification == false)
            {
                response.Success = false;
                response.Message = "Error: Input for products was invalid";
                return response;
            }
            else
            {
                
                response.Success = true;
                response.OrderNumber = orderRepo.NextOrderNumber();
                response.Date = dateTime;
                response.StringDate = dateTime.ToString();
                response.State = state;
                response.Tax = taxes.FirstOrDefault(t => t.StateAbbreviation == response.State).TaxRate;
                response.Product = productType;
                response.CostPerSquareFoot = products.FirstOrDefault(p => p.ProductsType == response.Product).CostPerSquareFoot;
                response.LaborCostPerSquareFoot = products.FirstOrDefault(p => p.ProductsType == response.Product).LaborCostPerSquareFoot;
                return response;
            }
        }

    }
}
