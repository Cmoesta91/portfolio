﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Crop.Models
{
    public class Orders
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost
        {
            get
            {
                return Area* CostPerSquareFoot;
            }
            set { }
        }
        public decimal LaborCost
        {
            get
            {
                return Area* LaborCostPerSquareFoot;
            }
            set
            {

            }
        }
        public decimal Tax
        {
            get
            {
                return (MaterialCost + LaborCost) * (TaxRate / 100);
            }
            set
            {

            }
        }
        public decimal Total
        {
            get
            {
                return MaterialCost + LaborCost + Tax;
            }
            set
            {

            }
        }
    }


}
