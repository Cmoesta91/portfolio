using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.ViewModels
{
    public class CarsSpecials
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Special> Specials { get; set; }
    }
}