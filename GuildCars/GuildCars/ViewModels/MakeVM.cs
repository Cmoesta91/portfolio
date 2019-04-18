using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.ViewModels
{
    public class MakeVM
    {
        public IEnumerable<Make> Makes { get; set; }
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }

    }
}