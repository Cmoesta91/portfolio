using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Crop.Models.Responses
{
    public class NewOrderResponse : Response 
    {

        public Orders Orders { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerNamer { get; set; }
        public string State { get; set; }
        public decimal Tax { get; set; }
        public string Product { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }

        public DateTime Date { get; set; }
        public string StringDate { get; set; }

    }
}
