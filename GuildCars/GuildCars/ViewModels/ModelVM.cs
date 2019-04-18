using GuildCars.Controllers;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.ViewModels
{
    public class ModelVM
    {
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<SelectListItem> MakesDropDown { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public string ModelName { get; set; }
        public int MakeID { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public IEnumerable<MakeAndModelCar> MakeModel { get; set; }
    }
}