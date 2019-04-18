using GuildCars.Models;
using GuildCars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GuildCars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new CarsSpecials();

            model.Cars = Factory.Create().FeaturedCars();
            model.Specials = Factory.SpecialRepo().Get();
           

            return View(model);
        }

        public ActionResult Contact(string vin)
        {
            var model = Factory.Create().GetByVin(vin);

            return View(model);
        }

        public ActionResult Special ()
        {
            var model = Factory.SpecialRepo().Get();

            return View(model);
        }

    }
}