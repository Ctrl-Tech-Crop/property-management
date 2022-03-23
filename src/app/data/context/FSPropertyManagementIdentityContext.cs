using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace data.context
{
    public class FSPropertyManagementIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public FSPropertyManagementIdentityContext(DbContextOptions<FSPropertyManagementIdentityContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasOne(d => d.Company)
                        .WithMany(p => p.ApplicationUsers)
                        .HasForeignKey(d => d.CompanyID)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Company_TO_ApplicationUser");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    options => options.EnableRetryOnFailure());
        }
    }
}
