using System;
using System.ComponentModel.DataAnnotations;

namespace CarListApp.Api.Models.Car
{
    public abstract class BaseCarDto
    {
        [Required]
        public string Make { get; set; }

        [Required]
        public string Plate { get; set; }

        public int Year { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DealershipId { get; set; }
    }
}