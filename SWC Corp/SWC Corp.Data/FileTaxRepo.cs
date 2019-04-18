using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Data
{
    public static class FileTaxRepo
    {
        static List<Taxes> taxes;

        public static List<Taxes> LoadTaxes()
        {

            List<Taxes> results = new List<Taxes>();

            StreamReader sr = null;
            try
            {

                sr = new StreamReader(@"C:\Users\camer\source\repos\SWC Corp\SWC Corp.UI\bin\Debug\Taxes.txt");
                sr.ReadLine();
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    Taxes t = TaxMapper.ToTaxes(row);
                    results.Add(t);
                }
                taxes = results;

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
