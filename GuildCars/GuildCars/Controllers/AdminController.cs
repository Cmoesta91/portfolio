using GuildCars.Data.Repos;
using GuildCars.Models;
using GuildCars.Models.Models;
using GuildCars.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Car = GuildCars.Models.Models.Car;

namespace GuildCars.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Vehicles()
        {
            var model = Factory.Create().Get();

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new VehicleVM();

            model.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
            model.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));


            return View(model);
        }

        [HttpPost]
        public ActionResult Add(VehicleVM vehicle)
        {
            int carMileage = int.Parse(vehicle.Mileage);
            decimal carPrice = (decimal)vehicle.SalePrice;
            decimal carMSRP = (decimal)vehicle.MSRP;


            if (carMileage >= 1000 && vehicle.CarType == "New")
            {
                vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
                vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));

                ModelState.AddModelError("Add", "Car cannot be new if mileage is 1000 or more");
                return View(vehicle);
            }

            if (carPrice > carMSRP)
            {
                vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
                vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));

                ModelState.AddModelError("Add", "Sale Price CANNOT be greater than MSRP");
                return View(vehicle);
            }

            if (ModelState.IsValid)
            {
                Make make = Factory.MakeRepo().GetById(vehicle.MakeID);

                Model carModel = Factory.ModelRepo().GetByID(vehicle.ModelID);

                carModel.Make = make;

                int returnInt = 0;
                
                Car car = new Car()
                {
                    Model = carModel,
                    Make = carModel.Make,
                    ModelID = vehicle.ModelID,
                    CarType = vehicle.CarType,
                    BodyStyle = vehicle.BodyStyle,
                    CarYear = vehicle.CarYear,
                    Trans = vehicle.Trans,
                    Color = vehicle.Color,
                    Interior = vehicle.Interior,
                    Mileage = vehicle.Mileage,
                    Vin = vehicle.Vin,
                    MSRP = vehicle.MSRP,
                    SalePrice = vehicle.SalePrice,
                    CarDescription = vehicle.CarDescription,
                };

                Factory.Create().Create(car);

                if (vehicle.CarPic != null && vehicle.CarPic.ContentLength > 0)
                {
                    string type = "." + vehicle.CarPic.ContentType.Substring(6);
                    vehicle.CarType = type;
                    if (type == ".png" || type == ".jpg" || type == ".jpeg")
                    {
                        returnInt = car.CarID;
                        car.PicturePath = "/Images/inventory-" + returnInt + type;
                        string path = Path.Combine(Server.MapPath(car.PicturePath));
                        if(System.IO.File.Exists(path))
                        {
                            System.IO.File.Delete(path);
                        }

                        vehicle.CarPic.SaveAs(path);
                        
                    }

                }

                return RedirectToAction("Vehicles");
            }

            vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
            vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));


            return View(vehicle);
        }

        [HttpGet]
        public ActionResult Edit(int carId, int makeId, int modelId)
        {
            var editCar = Factory.Create().GetById(carId);

            var model = new VehicleVM()
            {

                CarID = editCar.CarID,
                BodyStyle = editCar.BodyStyle,
                CarDescription = editCar.CarDescription,
                CarType = editCar.CarType,
                CarYear = editCar.CarYear,
                Color = editCar.Color,
                Interior = editCar.Interior,
                Mileage = editCar.Mileage,
                MSRP = editCar.MSRP,
                SalePrice = editCar.SalePrice,
                Trans = editCar.Trans,
                Vin = editCar.Vin,
                IsFeatured = editCar.IsFeatured,
            };

            model.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
            model.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VehicleVM vehicle)
        {
            
            int.TryParse(vehicle.Mileage, out int carMileage);
            decimal carPrice = (decimal)vehicle.SalePrice;
            decimal carMSRP = (decimal)vehicle.MSRP;

            if (carMileage >= 1000 && vehicle.CarType == "New")
            {
                vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
                vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));

                ModelState.AddModelError("Add", "Car cannot be new if mileage is 1000 or more");
                
                return View(vehicle);
            }

            if (carPrice > carMSRP)
            {
                vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
                vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));

                ModelState.AddModelError("Add", "Sale Price CANNOT be greater than MSRP");
                return View(vehicle);
            }

            if (ModelState.IsValid)
            {
                Model carModel = new Model();

                carModel = Factory.ModelRepo().GetByID(vehicle.ModelID);

                Make make = new Make();

                make = Factory.MakeRepo().GetById(vehicle.MakeID);

                Car car = new Car()
                {
                    CarID = vehicle.CarID,
                    Make = make,
                    Model = carModel,
                    ModelID = vehicle.ModelID,
                    CarType = vehicle.CarType,
                    BodyStyle = vehicle.BodyStyle,
                    CarYear = vehicle.CarYear,
                    Trans = vehicle.Trans,
                    Color = vehicle.Color,
                    Interior = vehicle.Interior,
                    Mileage = vehicle.Mileage,
                    Vin = vehicle.Vin,
                    MSRP = vehicle.MSRP,
                    SalePrice = vehicle.SalePrice,
                    CarDescription = vehicle.CarDescription,
                    IsFeatured = vehicle.IsFeatured,
                };

                Factory.Create().Update(car);

                return RedirectToAction("Vehicles");
            }

            vehicle.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));
            vehicle.ModelsDropDown = new SelectList(Factory.ModelRepo().Get(), nameof(Model.ModelID), nameof(Model.ModelName));


            return View(vehicle);

        }

        [HttpGet]
        public ActionResult DeleteCar(int id)
        {
            Car model = Factory.Create().GetById(id);
            Factory.Create().Delete(model.CarID);
            return RedirectToAction("Vehicles");
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult EditUser()
        {
            return View();
        }

        public ActionResult Makes()
        {
            var model = new MakeVM();

            model.Makes = Factory.MakeRepo().Get();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(MakeVM make)
        {
            Make model = new Make();
            {
                model.MakeName = make.MakeName;
                model.DateAdded = DateTime.Now;
                model.UserId = "1";
            }

            Factory.MakeRepo().Create(model);

            return RedirectToAction("Makes");
        }

        public ActionResult Models()
        {
            var model = new ModelVM();

            model.Models = Factory.ModelRepo().Get();
            model.Makes = Factory.MakeRepo().Get();

            var query =
               from carModel in model.Models
               join carMake in model.Makes on carModel.MakeID equals carMake.MakeID
               select new MakeAndModelCar { AnonMake = carMake.MakeName, AnonModel = carModel.ModelName, DateAdded = carModel.DateAdded, UserId = carModel.UserId };

            model.MakeModel = query;

            model.MakesDropDown = new SelectList(Factory.MakeRepo().Get(), nameof(Make.MakeID), nameof(Make.MakeName));

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(ModelVM carModel)
        {

            Model model = new Model();
            {
                model.ModelName = carModel.ModelName;
                model.MakeID = carModel.MakeID;
                model.DateAdded = DateTime.Now;
                model.UserId = "1";
            }

            Factory.ModelRepo().Create(model);

            return RedirectToAction("Models");
        }

        public ActionResult Specials()
        {
            var model = new SpecialVM();

            model.Specials = Factory.SpecialRepo().Get();

            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            Special model = Factory.SpecialRepo().GetById(id);
            Factory.SpecialRepo().Delete(model.SpecialID);
            return RedirectToAction("Specials");
        }

        [HttpPost]
        public ActionResult Specials(SpecialVM special)
        {
            if (ModelState.IsValid)
            {
                Special model = new Special();
                {
                    model.SpecialName = special.Title;
                    model.SpecialDescription = special.Description;
                }

                Factory.SpecialRepo().Create(model);

                return RedirectToAction("Specials");
            }

            special.Specials = Factory.SpecialRepo().Get();

            return View(special);
        }
    }
}