using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models;
using WareHouse.Models.CurrenciesPrice;
using WareHouse.Models.InformationUser;
using WareHouse.Models.RawMaterials;

namespace WareHouse.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // information User
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<AccountBank> accountBanks { get; set; }
        public DbSet<TitleJobs> TitleJobs { get; set; }


        // RawMaterials
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<RelatedToProperty> RelatedToProperties { get; set; }

        public DbSet<CurrencyPrice> CurrenciesPrice { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // RawMaterials
            builder.Entity<RawMaterial>()
                .HasIndex(u => u.PartNumber)
                .IsUnique();
            builder.Entity<Property>()
                .HasIndex(u => u.Name)
                .IsUnique();


        }
    }
}
