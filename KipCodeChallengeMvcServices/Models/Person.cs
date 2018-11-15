﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KipCodeChallengeMvcPerson.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
