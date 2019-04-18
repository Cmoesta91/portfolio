using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            var model = Factory.Create().FeaturedCars();

            return View(model);
        }

        public ActionResult Purchase(int id)
        {
            var model = Factory.Create().GetById(id);

            return View(model);
        }
    }
}