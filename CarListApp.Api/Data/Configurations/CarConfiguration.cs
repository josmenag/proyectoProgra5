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
                        Make = "Mercedes-Benz",
                        Model = "C-Class",
                        DealershipId = 1,
                        Vin = "4345"
                    },
                    new Car
                    {
                        Id = 2,
                        Make = "Bentley",
                        Model = "Mulliner",
                        DealershipId = 2,
                        Vin = "5443"
                    },
                    new Car
                    {
                        Id = 3,
                        Make = "Audi",
                        Model = "A8",
                        DealershipId = 1,
                        Vin = "5343"
                    }
                );
        }
    }
}

