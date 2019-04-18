﻿using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Data
{
    public class OrderMapper
    {
        public static Orders ToOrder(string row)
        {
            Orders o = new Orders();
            string[] fields = row.Split(',');
            o.OrderNumber = int.Parse(fields[0]);
            o.CustomerName = fields[1];
            o.State = fields[2];
            o.TaxRate = decimal.Parse(fields[3]);
            o.ProductType = fields[4];
            o.Area = decimal.Parse(fields[5]);
            o.CostPerSquareFoot = decimal.Parse(fields[6]);
            o.LaborCostPerSquareFoot = decimal.Parse(fields[7]);
            

            return o;

        }

        public static string ToStringCSV(Orders o)
        {
            string row = $"{o.OrderNumber},{o.CustomerName},{o.State},{o.TaxRate},{o.ProductType},{o.Area}," +
                $"{o.CostPerSquareFoot},{o.LaborCostPerSquareFoot},{o.MaterialCost},{o.LaborCost},{o.Tax},{o.Total}";

            return row;
        }
    }
}
