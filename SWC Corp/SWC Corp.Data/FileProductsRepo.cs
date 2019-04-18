using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Data
{
    public static class FileProductsRepo
    {
         static List<Products> products;
        

        public static List<Products> LoadProducts()
        {

            List<Products> results = new List<Products>();

            StreamReader sr = null;
            try
            {
               
                sr = new StreamReader(@"C:\Users\camer\source\repos\SWC Corp\SWC Corp.UI\bin\Debug\Products.txt");
                sr.ReadLine();
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    Products p = ProductMapper.ToProduct(row);
                    results.Add(p);
                }
                products = results;

            }
            catch (FileNotFoundException filenNotFound)
            {
                Console.WriteLine(filenNotFound.FileName + " was not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return results;

        }
    }
}
