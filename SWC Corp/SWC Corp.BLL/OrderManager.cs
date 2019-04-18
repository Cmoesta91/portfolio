using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Corp.Data;
using SWC_Crop.Models;
using SWC_Crop.Models.Responses;
using System.Globalization;

namespace SWC_Corp.BLL
{
    public class OrderManager
    {
        private IFileOrderRepo _fileOrderRepo;

        public OrderManager(IFileOrderRepo fileOrderRepo)
        {
            _fileOrderRepo = fileOrderRepo;
        }

        public OrderLookupResponse LookupOrders (string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.orders = _fileOrderRepo.LoadOrder();

            if (response.orders == null)
            {
                response.Success = false;
                response.Message = $"Orders_{orderDate} is not a valid account.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        




    }
}
