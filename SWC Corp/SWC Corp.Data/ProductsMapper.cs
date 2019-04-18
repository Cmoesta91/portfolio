using SWC_Crop.Models;

namespace SWC_Corp.Data
{
    public class ProductMapper
    {
        public static Products ToProduct(string row)
        {
            Products p = new Products();
            string[] fields = row.Split(',');
            p.ProductsType= fields[0];
            p.CostPerSquareFoot =decimal.Parse(fields[1]);
            p.LaborCostPerSquareFoot = decimal.Parse(fields[2]);

            return p;
        }
    }
}