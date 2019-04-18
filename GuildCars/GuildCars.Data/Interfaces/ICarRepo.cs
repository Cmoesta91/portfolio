using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models
{
    public interface ICarRepo
    {
        Car Create(Car car);
        void Update(Car car);
        void Delete(int id);
        Car GetById(int id);
        IEnumerable<Car> Get();
        IEnumerable<Car> GetByType(string type);
        IEnumerable<Car> GetByMake(string make);
        IEnumerable<Car> GetByModel(string model);
        IEnumerable<Car> GetByYear(string year);
        IEnumerable<Car> GetByPrice(decimal price);
        Car GetByVin(string vin);
        IEnumerable<Car> FeaturedCars();
        IEnumerable<Car> Search(string searchtype, string term, decimal minPriceBar, decimal maxPriceBar, string minYearBar, string maxYearBar);

    }
}
