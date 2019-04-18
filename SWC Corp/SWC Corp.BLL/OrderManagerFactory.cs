using SWC_Corp.Data;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Corp.BLL
{
    public class OrderManagerFactory
    {
        public static OrderManager Create(string date)
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch(mode)
            {
                case "Production":
                    return new OrderManager(new FileOrderRepo(date));
                case "Test":
                    return new OrderManager(new TestRepo());
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
