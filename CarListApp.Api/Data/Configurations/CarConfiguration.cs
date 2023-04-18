using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarListApp.Api.Data.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car
                {
                    Id = 1,
                    Make = "Audi",
                    Model = "e-tron GT",
                    DealershipId = 1,
                    Vin = 5133
                },
                new Car
                {
                    Id = 2,
                    Make = "Lexus",
                    Model = "LS",
                    DealershipId = 1,
                    Vin = 848
                },
                new Car
                {
                    Id = 3,
                    Make = "Jaguar",
                    Model = "I-Pace",
                    DealershipId = 2,
                    Vin = 2020
                }
            );
        }
    }
}

