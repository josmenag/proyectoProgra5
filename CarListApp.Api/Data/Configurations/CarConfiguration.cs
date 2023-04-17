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
                    Make = "My Make",
                    Plate = "PL4T3",
                    DealershipId = 1,
                    Year = 2023
                },
                new Car
                {
                    Id = 2,
                    Make = "MC Laren",
                    Plate = "F45T",
                    DealershipId = 1,
                    Year = 2015
                },
                new Car
                {
                    Id = 3,
                    Make = "Bently",
                    Plate = "B4D13",
                    DealershipId = 2,
                    Year = 2020
                }
            );
        }
    }
}

