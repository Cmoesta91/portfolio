using GuildCars.Data.Interfaces;
using GuildCars.Data.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class Factory
    {
        public static ICarRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();


            switch (mode)
            {
                case "PROD":
                    return new MockCarRepo();
                //        case "EFDVDRepo":
                //            return new EFDVDRepo();
                //        case "ADODVDRepo":
                //            return new ADODVDRepo();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static ISpecialRepo SpecialRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "PROD":
                    return new MockSpecialRepo();
                //        case "EFDVDRepo":
                //            return new EFDVDRepo();
                //        case "ADODVDRepo":
                //            return new ADODVDRepo();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IMake MakeRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "PROD":
                    return new MockMakeRepo();
                //        case "EFDVDRepo":
                //            return new EFDVDRepo();
                //        case "ADODVDRepo":
                //            return new ADODVDRepo();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

        public static IModel ModelRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "PROD":
                    return new MockModelRepo();
                //        case "EFDVDRepo":
                //            return new EFDVDRepo();
                //        case "ADODVDRepo":
                //            return new ADODVDRepo();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}