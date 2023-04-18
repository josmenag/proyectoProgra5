using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
<<<<<<< HEAD
=======
using System.Diagnostics.Metrics;
>>>>>>> addingAPI

namespace CarListApp.Api.Data.Configurations
{
    public class DealershipConfiguration : IEntityTypeConfiguration<Dealership>
    {
        public void Configure(EntityTypeBuilder<Dealership> builder)
        {
            builder.HasData(
<<<<<<< HEAD
                    new Dealership
                    {
                        Id = 1,
                        Name = "San Jose",
                        Address = "Sabana Norte"
                    },
                    new Dealership
                    {
                        Id = 2,
                        Name = "Heredia",
                        Address = "Paseo de las Flores"
                    },
                    new Dealership
                    {
                        Id = 3,
                        Name = "Puntarenas",
                        Address = "Jaco"
                    }
                );
=======
                new Dealership
                {
                    Id = 1,
                    Name = "SJO",
                    Address = "San Jose"
                },
                new Dealership
                {
                    Id = 2,
                    Name = "Cartago",
                    Address = "Tres Rios"
                },
                new Dealership
                {
                    Id = 3,
                    Name = "Alajuela",
                    Address = "La Fortuna"
                }
            );
>>>>>>> addingAPI
        }
    }
}

