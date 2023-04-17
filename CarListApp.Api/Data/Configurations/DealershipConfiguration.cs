using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;

namespace CarListApp.Api.Data.Configurations
{
    public class DealershipConfiguration : IEntityTypeConfiguration<Dealership>
    {
        public void Configure(EntityTypeBuilder<Dealership> builder)
        {
            builder.HasData(
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
        }
    }
}

