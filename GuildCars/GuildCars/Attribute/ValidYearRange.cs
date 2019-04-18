using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Attribute
{
    public class ValidYearRange : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if (value is string)
            {
                int Number = 0;

                string checkString = (string)value;

                bool res = int.TryParse(checkString, out Number);

                if (res == false)
                {
                    return false;
                }

                if (Number > DateTime.Now.Year + 1)
                {
                    return false;
                }

                if(Number < 2000)
                {
                    return false;
                }

                return true;

            }

            return false;

        }
    }
}