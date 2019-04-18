using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Crop.Models.Responses
{
    public class OrderLookupResponse : Response
    {
        public List<Orders> orders { get; set; }
    }
}
