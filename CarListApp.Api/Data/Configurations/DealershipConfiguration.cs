using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
                        Name = "Brasil",
                        Address = "Sao Paulo"
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

