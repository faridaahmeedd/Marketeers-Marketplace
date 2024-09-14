using MarketeersMarketplace.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketeersMarketplace.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Talent> Talents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }

        //public DbSet<Business> Business { get; set; }
        //public DbSet<Campaign> Campaigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Talent>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Talents);
            modelBuilder
                .Entity<Talent>()
                .HasMany(p => p.Images)
                .WithOne(p => p.Talent);

            modelBuilder
                .Entity<Talent>()
                .HasBaseType<AppUser>();

            SeedRole(modelBuilder);
        }

        private void SeedRole(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                    new IdentityRole() { Id = "6e83945a-31f7-4a85-9679-e5e12895df12", Name = "Talent", ConcurrencyStamp = "1", NormalizedName = "Customer" },
                    //new IdentityRole() { Id = "43626702-ab6b-4481-89f0-769da1a485c2", Name = "Business", ConcurrencyStamp = "2", NormalizedName = "Provider" },
                    new IdentityRole() { Id = "fee70a81-e665-4566-afc0-5d0c84e3f4fe", Name = "Admin", ConcurrencyStamp = "3", NormalizedName = "Admin" },
                    new IdentityRole() { Id = "5fe9bbcd-eb74-448e-9580-1c4bd31f7958", Name = "SuperAdmin", ConcurrencyStamp = "4", NormalizedName = "SuperAdmin" }
                );
        }
    }
}