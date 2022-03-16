using System;
using data.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace data.context
{
    public partial class FSPropertyManagementContext : DbContext
    {
        public FSPropertyManagementContext()
        {
        }

        public FSPropertyManagementContext(DbContextOptions<FSPropertyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.HasOne(e => e.Company)
                //.WithMany(p => p.Properties)
                //.HasForeignKey(e => e.CompanyID)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("FK_Company_TO_Property");
                             
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("PropertyType");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.ToTable("Tenant");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactEmail)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressLine1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MailingAddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PreferredName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Standing)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TenancyStartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Unit_TO_Tenant");


                //entity.HasOne(e => e.Company)
                //.WithMany(p => p.Tenants)
                //.HasForeignKey(e => e.CompanyID)
                //.OnDelete(DeleteBehavior.ClientSetNull)
                //.HasConstraintName("FK_Company_TO_Tenant");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Area).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DepositAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RentAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Furnished).IsRequired();
                entity.Property(e => e.Laundry).IsRequired();

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Property_TO_Unit");

                entity.HasOne(d => d.UnitType)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.UnitTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PropertyType_TO_Unit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
