﻿using System;
using CarListApp.Api.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarListApp.Api.Data
{
    public class CarsInventoryDBContext : IdentityDbContext<ApiUser>
    {
        public CarsInventoryDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new DealershipConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());


            modelBuilder.Entity<Dealership>()
                .Property(e => e.Name)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters
            modelBuilder.Entity<Dealership>()
                .Property(e => e.Address)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters
            modelBuilder.Entity<Car>()
                .Property(e => e.Make)
                .HasMaxLength(100); // Set the maximum length of the property to 100 characters
            modelBuilder.Entity<Car>()
                .Property(e => e.Model)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters
            modelBuilder.Entity<Car>()
                .Property(e => e.Vin)
                .HasMaxLength(50); // Set the maximum length of the property to 50 characters
        }
    }
}

