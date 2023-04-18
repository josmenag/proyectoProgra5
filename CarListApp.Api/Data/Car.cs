﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace CarListApp.Api.Data
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Vin { get; set; }

        [ForeignKey(nameof(DealershipId))]
        public int DealershipId { get; set; }
        public Dealership Dealership { get; set; }
    }
}