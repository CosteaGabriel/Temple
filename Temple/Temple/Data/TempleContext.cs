using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Temple.Models;
using Microsoft.EntityFrameworkCore;

namespace Temple.Data
{
    public class TempleContext : DbContext
    {
        public TempleContext(DbContextOptions<TempleContext> options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Distribution> Distributions { get; set; }
        public DbSet<Pacient> Pacients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctor");
            modelBuilder.Entity<Distribution>().ToTable("Distribution");
            modelBuilder.Entity<Pacient>().ToTable("Pacient");
        }
    }
}
