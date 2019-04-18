using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Course : IValidatableObject
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(CourseName))
            {
                errors.Add(new ValidationResult("Please enter a Course name",
                    new[] { "CourseName" }));
            }

            return errors;
        }
    }

    
}