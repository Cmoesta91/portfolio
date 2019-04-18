using GuildCars.Models.Models;
using System;

namespace GuildCars.Controllers
{
    public class MakeAndModelCar
    {
        public string AnonMake { get; set; }
        public string AnonModel { get; set; }
        public DateTime? DateAdded { get; set; }
        public string UserId { get; set; }
    }
}