using GuildCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class InventoryController : Controller
    {
        public ActionResult Details(int id)
        {
            var model = Factory.Create().GetById(id);

            return View(model);
        }

        public ActionResult NewCars ()
        {
            var model = Factory.Create().GetByType("New");

            return View(model);
        }

        public ActionResult UsedCars()
        {
            var model = Factory.Create().GetByType("Used");

            return View(model);
        }
    }
}