using NUnit.Framework;
using SWC_Corp.BLL;
using SWC_Corp.BLL.RulesForOrders;
using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Tests
{
    [TestFixture]
    class Tests
    {
       

        [TestCase(1, "Bob", "MI", 5.75, "Salad", 100, 5.15, 4.75, false)]
        [TestCase(1, "Bob", "MS", 5.75, "Wood", 100, 5.15, 4.75, false)]
        [TestCase(1, "Bob", "MI", 5.75, "Wood", 100, 5.15, 4.75, true)]
        public void TestingOrderRules(int orderNumber, string customerName, string stateAbbreviation, decimal taxrate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, bool expectedResult)
        {
            
            DateTime dateTime = DateTime.Parse("01/01/2020");
            Orders testOrder = new Orders() { State = stateAbbreviation, ProductType = productType };
            NewOrderResponse response = new NewOrderResponse();
            response = NewOrderRules.NewOrder(dateTime, testOrder.State, testOrder.ProductType);

            Assert.AreEqual(response.Success, expectedResult);
        }

        [TestCase ()]
        [TestCase ("12125000", true)]
        public void TestDisplay(string date, bool expectedResults)
        {
            OrderManager orderManager = OrderManagerFactory.Create(date);
            OrderLookupResponse response = new OrderLookupResponse();

            response = orderManager.LookupOrders(date);

            Assert.AreEqual(response.Success, expectedResults);
        }



    }
}
