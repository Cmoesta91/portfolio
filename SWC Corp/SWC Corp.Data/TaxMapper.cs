using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Data
{
    public class TaxMapper
    {
        public static Taxes ToTaxes(string row)
        {
            Taxes t = new Taxes();
            string[] fields = row.Split(',');
            t.StateAbbreviation = fields[0];
            t.StateName = fields[1];
            t.TaxRate = decimal.Parse(fields[2]);

            return t;
        }
    }
}
