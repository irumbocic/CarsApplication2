using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Service.EfStructure
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base (options)
        {
        }

        public  DbSet<VehicleMake> VehicleMakes { get; set; }
        public  DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>()
                .HasMany(e => e.VehicleModels)
                .WithOne(e => e.VehicleMake)
                .HasForeignKey(e => e.MakeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
