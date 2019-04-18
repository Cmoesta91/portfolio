using SWC_Crop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.Data
{
    public class FileOrderRepo : IFileOrderRepo
    {
        protected List<Orders> orders = new List<Orders>();
        private readonly string FILENAME;

        public FileOrderRepo(string path)
        {
            FILENAME = path;
        }

        public int NextOrderNumber()
        {
            orders = LoadOrder();

            int orderNumber = 0;
            foreach (Orders order in orders)
            {
                if (order.OrderNumber > orderNumber)
                {
                    orderNumber = order.OrderNumber;
                }
            }
            orderNumber = orderNumber + 1;
            return orderNumber;
        }

        public Orders Create(Orders order)
        {
            order.OrderNumber = NextOrderNumber();
            orders.Add(order);
            SaveOrder();
            return order;
        }

        public virtual Orders ReadByOrderNumber(int orderNumber)
        {
            foreach (Orders order in orders)
            {
                if (order.OrderNumber == orderNumber)
                {
                    return order;
                }
            }
            return null;
        }

        public void Update(int orderNumber, Orders newOrderInfo)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderNumber != orderNumber) continue;
                orders[i] = newOrderInfo;
                break;
            }
            SaveOrder();
        }

        public void Delete(int orderNumber, Orders order)
        {
            orders.RemoveAll((Orders orderInfo) => orderInfo.OrderNumber == orderNumber);
            SaveOrder();
        }

        public List<Orders> LoadOrder()
        {
            List<Orders> results = new List<Orders>();

            StreamReader sr = null;
            try
            {
                //date needs to be a varible that is gotten from...something...
                sr = new StreamReader(FILENAME);
                sr.ReadLine();
                string row = "";
                while ((row = sr.ReadLine()) != null)
                {
                    Orders o = OrderMapper.ToOrder(row);
                    results.Add(o);
                }
                orders = results;

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

        public void SaveOrder()
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(FILENAME);
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (Orders order in orders)
                {
                    sw.WriteLine(OrderMapper.ToStringCSV(order));
                    sw.Flush();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }
        
    }
}
