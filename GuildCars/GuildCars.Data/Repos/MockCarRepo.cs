using GuildCars.Models.Models;
using System.Collections.Generic;
using System;
using System.Linq;

using Make = GuildCars.Models.Models.Make;
using Model = GuildCars.Models.Models.Model;
using GuildCars.Data.Interfaces;

namespace GuildCars.Models
{
    internal class MockCarRepo : ICarRepo
    {
        private static List<Car> _cars;
        private static Make _make;
        private static Make _make2;
        private static Model _model;
        private static Model _model2;

        static MockCarRepo()
        {
            _make = new Make
            {
                MakeID = 1,
                MakeName = "Honda",
                DateAdded = new DateTime(02 / 20 / 2019),
                UserId = "1"
            };

            

            _make2 = new Make
            {
                MakeID = 2,
                MakeName = "Ford",
                DateAdded = new DateTime(02 / 20 / 2019),
                UserId = "1"
            };

            _model = new Model
            {
                ModelID = 1,
                ModelName = "Civic",
                DateAdded = new DateTime(02 / 20 / 2019),
                MakeID = 1,
                UserId = "1"
            };

            _model2 = new Model
            {
                ModelID = 2,
                ModelName = "F-150",
                DateAdded = new DateTime(02 / 20 / 2019),
                MakeID = 2,
                UserId = "1"
            };

            _cars = new List<Car>()
            {
                new Car {Model = _model,
                        Make = _make,
                        CarID = 1,
                        ModelID = 1,
                        CarYear = "2001",
                        BodyStyle = "Sedan",
                        Trans = "Automatic",
                        Color = "Blue",
                        Interior = "Grey",
                        Mileage = "100000",
                        SalePrice = 3000,
                        MSRP = 4000,
                        CarDescription = "Tincidunt in condimentum dictumst turpis, amet eum dolor praesent placerat, risus sed proin dis, nunc etiam, nostra lacinia hymenaeos. Vel amet dapibus mollis maecenas ipsum, ipsum laoreet vestibulum augue felis. Sed phasellus posuere integer. Placerat nullam placerat nonummy nisl urna, aliquam amet sed ante eu vulputate, justo nam volutpat non. Sollicitudin tortor lectus est lorem suscipit porta, viverra nunc gravida dui enim.",
                        CarType = "Used",
                        Vin = "5XXGR4A67DG128805",
                        IsFeatured = true,
                        PicturePath = "/Images/inventory-1.jpg",
                },

                new Car {Model = _model2,
                        Make = _make2,
                        CarID = 2,
                        ModelID = 2,
                        CarYear = "2012",
                        BodyStyle = "Truck",
                        Trans = "Automatic",
                        Color = "Green",
                        Interior = "Black",
                        Mileage = "150000",
                        SalePrice = 20000,
                        MSRP = 30000,
                        CarDescription = "Ante felis nibh quibusdam mauris proin, consequat fringilla aenean scelerisque wisi, ac a ut nostra, nonummy curae massa diam velit, ipsum sed vitae. Mauris justo lorem nunc dui vitae, quam ultrices. Sed nec duis orci. Integer non suscipit, id pede eget tincidunt interdum illum, pellentesque lacus adipiscing pede sagittis, enim class massa. Vel vel varius vestibulum suspendisse vivamus, et lorem, mollis leo praesent tellus. Justo libero, ac lectus consectetuer orci auctor, praesent wisi morbi dui morbi ante pellentesque, et nisl duis erat, sit mattis tincidunt dictum.",
                        CarType = "Used",
                        Vin = "3N1AB7AP5EY206191",
                        IsFeatured = true,
                        PicturePath = "/Images/inventory-2.jpg",
                }
            };


        }

        public Car Create(Car newCar)
        {
            if (_cars.Any())
            {
                newCar.CarID = _cars.Max(c => c.CarID) + 1;
            }
            else
            {
                newCar.CarID = 0;
            }

            _cars.Add(newCar);
            return newCar;
        }

        public void Delete(int id)
        {
            _cars.RemoveAll(c => c.CarID == id);
        }

        public IEnumerable<Car> Get()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.CarID == id);
        }

        public Car GetByVin(string vin)
        {
            return _cars.FirstOrDefault(c => c.Vin == vin);
        }

        public IEnumerable<Car> GetByMake(string make)
        {
            return _cars.Where(c => c.Model.Make.MakeName == make);
        }

        public IEnumerable<Car> GetByModel(string model)
        {
            return _cars.Where(c => c.Model.ModelName == model);
        }

        public IEnumerable<Car> GetByPrice(decimal price)
        {
            return _cars.Where(c => c.SalePrice == price);
        }

        public IEnumerable<Car> GetByYear(string year)
        {
            return _cars.Where(c => c.CarYear == year);
        }

        public void Update(Car updatedCar)
        {

            _cars.RemoveAll(c => c.CarID == updatedCar.CarID);
            _cars.Add(updatedCar);
        }

        public IEnumerable<Car> FeaturedCars()
        {
            return _cars.Where(c => c.IsFeatured == true);
        }

        public IEnumerable<Car> GetByType(string type)
        {
            if (type == "Used")
            {
                return _cars.Where(c => c.CarType == type);
            }
            else if (type == "New")
            {
                return _cars.Where(c => c.CarType == type);
            }
            else
            {
                return _cars.Where(c => c.CarType == type);
            }
        }

        public IEnumerable<Car> Search(string searchtype, string term, decimal minPriceBar, decimal maxPriceBar, string minYearBar, string maxYearBar)
        {
            IMake makeRepo = Factory.MakeRepo();
            IModel modelRepo = Factory.ModelRepo();
            IEnumerable<Car> cars = new List<Car>();
            switch (searchtype)
            {
                case "new":
                    cars = Get().Where(c => c.CarType == "New");
                    break;
                case "used":
                    cars = Get().Where(c => c.CarType == "Used");
                    break;
                case "all":
                    cars = Get();
                    break;
                default:
                    break;
            }
            List<Car> found = new List<Car>();
            int minYear = 0;
            int maxYear = 0;

            int.TryParse(minYearBar, out minYear);
            int.TryParse(maxYearBar, out maxYear);

            int Year = 0;
            int.TryParse(term, out Year);

            foreach (var car in cars)
            {
                int carYear = int.Parse(car.CarYear);
                
                car.Model = modelRepo.GetByID(car.ModelID);
                car.Model.Make = makeRepo.GetById(car.Model.MakeID);

                if(carYear >= minYear && int.Parse(car.CarYear) <= maxYear && car.SalePrice >= minPriceBar && car.SalePrice <= maxPriceBar)
                {
                    if (term != "hamster")
                    {
                        if (carYear == Year || car.Model.Make.MakeName.ToLower().Contains(term.ToLower()) || car.Model.ModelName.ToLower().Contains(term.ToLower()))
                        {
                            found.Add(car);
                        }
                    }

                    else
                    {
                        found.Add(car);
                    }
                }
            }

            cars = found;
            return cars;
        }
    }
}