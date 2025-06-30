using Agriculture_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agriculture_Management_System.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }
        public DbSet<Crops> Crops { get; set; }
        public DbSet<OrderRequest> OrderRequest { get; set; }
        public DbSet<OrderRequestItems> OrderRequestItems { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderRequest>(entity =>
            {
               
                entity.HasOne(o => o.Farmer)
                      .WithMany()
                      .HasForeignKey(o => o.FarmerID)
                      .OnDelete(DeleteBehavior.Restrict); 

               
                entity.HasOne(o => o.Buyer)
                      .WithMany()
                      .HasForeignKey(o => o.BuyerID)
                      .OnDelete(DeleteBehavior.Restrict); 
            });
        }

    }
}
