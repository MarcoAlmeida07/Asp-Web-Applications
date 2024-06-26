﻿using System.ComponentModel.DataAnnotations;

namespace RunWebApp.Models
{
    public class Adress
    {
        public class Address
        {
            [Key]
            public int Id { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public int ZipCode { get; set; }
        }
    }
}
