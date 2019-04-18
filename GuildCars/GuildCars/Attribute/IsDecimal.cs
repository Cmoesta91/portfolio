using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuildCars.Attribute
{
    public class IsDecimal : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is decimal checkDecimal)
            {
                if (checkDecimal < 0m)
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}