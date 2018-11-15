using KipCodeChallengeMvcPerson.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace KipCodeChallengeMvc.Models
{
    public class PersonModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string DateOfBirth { get; set; }

        public static explicit operator PersonModel(Person person)
        {
            return new PersonModel
            {
                FirstName = person?.FirstName,
                LastName = person?.LastName,
                Email = person?.Email,
                DateOfBirth = person?.DateOfBirth?.ToString("d MMMM, yyyy")
            };
        }
        public static explicit operator Person(PersonModel personModel)
        {
            var dateOfBirth = null as DateTime?;

            if (DateTime.TryParse(personModel.DateOfBirth, out var dateOfBirthConverted))
            {
                dateOfBirth = dateOfBirthConverted;
            }

            return new Person
            {
                FirstName = personModel?.FirstName,
                LastName = personModel?.LastName,
                Email = personModel?.Email,
                DateOfBirth = dateOfBirth
            };
        }
    }
}
