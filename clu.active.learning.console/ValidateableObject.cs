using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace clu.active.learning.console
{
    public class ValidateableObject
    {
        public class Student : IValidatableObject
        {
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                throw new NotImplementedException();
            }
        }

        public class Person : IValidatableObject
        {
            public int Id { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Address { get; set; }

            [Required]
            public DateTime BirthDate { get; set; }

            [Required]
            public int Income { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                var pIncome = new[] { "Income" };
                if (Income < 0)
                {
                    yield return new ValidationResult("Income cannot be negative", pIncome);
                }

                var pName = new[] { "Name" };
                if (Name.Length > 40)
                {
                    yield return new ValidationResult("Name cannot be such huge in length", pName);
                }

                var pBDate = new[] { "BirthDate" };
                if (BirthDate > DateTime.Now)
                {
                    yield return new ValidationResult("Sorry Future Date cannot be accepted.", pBDate);
                }

                // or return all validation results (not using yield
            }
        }

        public static void Test()
        {
            var person = new Person
            {
                Income = 1500,
                Name = "Doe",
                BirthDate = DateTime.Now.AddYears(-18),
                Address = "Microsoft Campus"
            };
            var context = new ValidationContext(person, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(person, context, results); // true

            Console.ReadLine();
        }
    }
}