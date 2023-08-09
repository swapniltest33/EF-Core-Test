using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Structure.Core.Models
{
    public partial class TestDBContext : DbContext
    {
        public TestDBContext() { }

        public TestDBContext(DbContextOptions<TestDBContext> options) : base(options)
        {

        }
       

       // public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Category> Category { get; set; } = null!;
       // public virtual DbSet<UserAdmin> UserAdmins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=PC0773\\MSSQL2019;Initial Catalog=TaskDB;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne<Category>(e => e.Category)
                .WithMany(e => e.products);
                entity.Property(e => e.ProductName).HasMaxLength(50).IsRequired()
                .IsConcurrencyToken();

            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasMany<Product>(e => e.products)
                .WithOne(e => e.Category);
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserAdmin>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserAdmin");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
