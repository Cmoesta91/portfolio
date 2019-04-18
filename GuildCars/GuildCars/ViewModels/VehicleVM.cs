using GuildCars.Attribute;
using GuildCars.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.ViewModels
{
    public class VehicleVM : ValidationAttribute
    {
        public IEnumerable<SelectListItem> MakesDropDown { get; set; }
        public IEnumerable<SelectListItem> ModelsDropDown { get; set; }
        public int CarID { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
        public Nullable<int> MakeID { get; set; }
        public Nullable<int> ModelID { get; set; }

        [Required(ErrorMessage = "Please enter the car year")]
        [StringLength(4)]
        [IsNumber(ErrorMessage = "Car year must be a valid number")]
        [ValidYearRange(ErrorMessage = "Car year cannot be less than 2000 or greater than the current year plus one")]
        public string CarYear { get; set; }

        [Required(ErrorMessage = "Please enter a body style")]
        public string BodyStyle { get; set; }

        [Required(ErrorMessage = "Please enter the transmission type")]
        public string Trans { get; set; }

        [Required(ErrorMessage = "Please enter car color")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Please enter car interior color")]
        public string Interior { get; set; }

        [Required(ErrorMessage = "Please enter car mileage")]
        [IsNumber(ErrorMessage = "Mileage must be a number and not negative")]
        public string Mileage { get; set; }

        [Required(ErrorMessage = "Please enter car sale price")]
        [IsDecimal(ErrorMessage = "Sale Price must be a number and not a negative")]
        public Nullable<decimal> SalePrice { get; set; }

        [Required(ErrorMessage = "Please enter car MSRP")]
        [IsDecimal(ErrorMessage = "MSRP must be a number and not a negative")]
        public Nullable<decimal> MSRP { get; set; }

        [Required(ErrorMessage = "Please enter the car year")]
        public string CarDescription { get; set; }

        [Required(ErrorMessage = "Please enter the car type")]
        public string CarType { get; set; }

        [Required(ErrorMessage = "Please enter car VIN")]
        public string Vin { get; set; }

        public bool IsFeatured { get; set; }

        public string PicPath { get; set; }

        public string PicType { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase CarPic { get; set; }
    }
}