using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student : IValidatableObject
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(FirstName))
            {
                errors.Add(new ValidationResult("Please enter a name",
                    new[] { "FirstName" }));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errors.Add(new ValidationResult("Please enter a name",
                    new[] { "LastName" }));
            }
            
            if (GPA < 0m)
            {
                errors.Add(new ValidationResult("GPA cannot be a NEGATIVE",
                    new[] { "GPA" }));
            }
            if (GPA > 4.00m)
            {
                errors.Add(new ValidationResult("GPA cannot higher than 4.00",
                    new[] { "GPA" }));
            }

            return errors;
        }
    }
}