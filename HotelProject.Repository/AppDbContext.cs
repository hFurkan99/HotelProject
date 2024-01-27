using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelProject.Repository
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetSection("ConnectionStrings").GetSection("DefaultSqlServer").Value
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Room>()
                .HasData(
                    new Room()
                    {
                        Id = 1,
                        Name = "Junior Suit",
                        Description = "JDFHGasdfjhdsf sdfkjhsd dsafjkhds",
                        Wifi = true,
                        BathCount = 1,
                        BedCount = 2,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        Price = 300,
                    },
                    new Room()
                    {
                        Id = 2,
                        Name = "Junior Suit 2",
                        Description = "JDFHGasdfjhdsf sdfkjhsd dsafjkhds",
                        Wifi = true,
                        BathCount = 1,
                        BedCount = 4,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = null,
                        Price = 600,
                    }
                );
        }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Critization> Critizations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
    }
}
