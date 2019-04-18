using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Models.ViewModels
{
    public class StateVM
    {
        public State State{ get; set; }
        public List<SelectListItem> ValidStates { get; set; }
    }
}