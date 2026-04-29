using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mini_ERP.Domain.Entities;


namespace Mini_ERP.Persistence.Contexts
{
    public class Mini_ErpAPIContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public Mini_ErpAPIContext(DbContextOptions<Mini_ErpAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<MilkCollection> MilkCollections { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MilkCollection>()
                .HasOne(x => x.CollectorEmployee)
                .WithMany(x => x.CollectedMilkCollections)
                .HasForeignKey(x => x.CollectorEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MilkCollection>()
                .HasOne(x => x.QualityEmployee)
                .WithMany(x => x.QualityMilkCollections)
                .HasForeignKey(x => x.QualityEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
