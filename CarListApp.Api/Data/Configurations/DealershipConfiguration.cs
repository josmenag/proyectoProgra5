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
                        Name = "Costa Rica",
                        Address = "San Jose"
                    },
                    new Dealership
                    {
                        Id = 2,
                        Name = "Germany",
                        Address = "Berlin"
                    },
                    new Dealership
                    {
                        Id = 3,
                        Name = "Italy",
                        Address = "Milan"
                    }
                );
        }
    }
}

