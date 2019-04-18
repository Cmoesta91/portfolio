using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.ViewModels
{
    public class SpecialVM : ValidationAttribute
    {
        public IEnumerable<Special> Specials { get; set; }
        [Required(ErrorMessage = "Special needs a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description cannot be blank")]
        public string Description { get; set; }
    }
}