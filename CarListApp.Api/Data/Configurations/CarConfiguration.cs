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
                        Make = "BMW",
                        Model = "5 series",
                        DealershipId = 1,
                        Vin = "F45T"
                    },
                    new Car
                    {
                        Id = 2,
                        Make = "Mercedes-Benz",
                        Model = "S-Class",
                        DealershipId = 3,
                        Vin = "K00L-13"
                    },
                    new Car
                    {
                        Id = 3,
                        Make = "Lamborghini",
                        Model = "Veneno",
                        DealershipId = 2,
                        Vin = "V123"
                    }
                );
        }
    }
}

