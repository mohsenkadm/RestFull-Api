using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestFull_Api.Models;
using RestFull_Api.Models.Entity;

namespace RestFull_Api.Data
{
    public class RestFull_ApiContext : DbContext
    {
        public RestFull_ApiContext (DbContextOptions<RestFull_ApiContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>()
                .HasOne(s => s.students)
               .WithOne(ad => ad.Gender)
                .HasForeignKey<Student>(ad => ad.Gander_Id);
        }
        public DbSet<employ> employ { get; set; }
        public DbSet<Student> Student { get; set; }
      
    }
}
