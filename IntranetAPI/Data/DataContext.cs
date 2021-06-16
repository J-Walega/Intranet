using IntranetAPI.Entities;
using IntranetAPI.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntranetAPI.Repo
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .Property(b => b.Category)
                .HasConversion<string>();

            modelBuilder.Entity<Link>()
                .Property(b => b.Category)
                .HasConversion<string>();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
