using DrinkingWoteApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkingWoteApp_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Consument> Consuments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CrewMember> Crewers { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Perumahan> Perumahans { get; set; }
        //public DbSet<ConsumentOrder> ConsumentOrders { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ConsumentOrder>()
        //        .HasKey(co => new { co.JoinConsumentId, co.JoinOrderId });
            
        //    modelBuilder.Entity<ConsumentOrder>()
        //        .HasOne(p => p.Consument)
        //        .WithMany(co => co.ConsumenOrders)
        //        .HasForeignKey(o => o.JoinConsumentId)
        //        .IsRequired(false)
        //       .OnDelete(DeleteBehavior.SetNull);
        //    modelBuilder.Entity<ConsumentOrder>()
        //       .HasOne(p => p.Order)
        //       .WithMany(co => co.ConsumentOrders)
        //       .HasForeignKey(o => o.JoinOrderId)
        //       .IsRequired(false)
        //       .OnDelete(DeleteBehavior.SetNull);
        //}

    }
}
