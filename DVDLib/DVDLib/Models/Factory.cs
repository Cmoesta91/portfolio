using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLib.Models
{
    public static class Factory
    {

        public static IDVDRepo Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();


            switch (mode)
            {
                case "DVDRepo":
                    return new DVDRepo();
                case "EFDVDRepo":
                    return new EFDVDRepo();
                case "ADODVDRepo":
                    return new ADODVDRepo();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }

    }
}