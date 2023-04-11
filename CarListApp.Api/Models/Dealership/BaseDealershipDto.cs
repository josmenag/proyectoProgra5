using System;
using System.ComponentModel.DataAnnotations;

namespace CarListApp.Api.Models.Dealership
{
    public class BaseDealershipDto
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}

