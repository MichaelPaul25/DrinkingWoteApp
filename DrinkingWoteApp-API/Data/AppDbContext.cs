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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relation User to Consument (One to One)
            modelBuilder.Entity<User>()
                        .HasOne(c => c.Consument)
                        .WithOne(u => u.User)
                        .HasForeignKey<Consument>("UserId");

            //Relation Order to Bill(One to One)
            //modelBuilder.Entity<Order>()
            //            .HasOne(o => o.Bill)
            //            .WithOne(b => b.Order)
            //            .HasForeignKey<Bill>("Order_Id");


            ////Relation Many to Many
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
        }

    }
}
