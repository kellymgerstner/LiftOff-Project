using LiftOff_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftOff_Project.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ServiceTag> ServiceTags { get; set; }

        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiceTag>()
                .HasKey(s => new { s.ServiceId, s.TagId });
        }

    }
}
