using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Crop.Models;

namespace SWC_Corp.Data
{
    public class TestRepo : IFileOrderRepo
    {
        private static Orders _order = new Orders
        {
            OrderNumber = 1,
            CustomerName = "Bob",
            State = "MI",
            TaxRate = 5.75m,
            ProductType = "Wood",
            Area = 100,
            CostPerSquareFoot = 5.15m,
            LaborCostPerSquareFoot = 4.75m,
        };

        private static List<Orders> orders = new List<Orders>
        {
            _order
        };

        public Orders Create(Orders order)
        {
            throw new NotImplementedException();
        }

        public void Delete(int orderNumber, Orders order)
        {
            throw new NotImplementedException();
        }

        public List<Orders> LoadOrder()
        {
            return orders;
        }

        public int NextOrderNumber()
        {
            throw new NotImplementedException();
        }

        public Orders ReadByOrderNumber(int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder()
        {
            throw new NotImplementedException();
        }

        public void Update(int orderNumber, Orders newOrderInfo)
        {
            throw new NotImplementedException();
        }
    }
}
