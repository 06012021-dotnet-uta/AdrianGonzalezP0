using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcommerceDbContext
{
    public partial class Project0Context : DbContext
    {
        public Project0Context()
        {
        }

        public Project0Context(DbContextOptions<Project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Project0;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_Username");

                entity.ToTable("Account");

                entity.Property(e => e.Username).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.Username, "IFK_Username");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactNumber).HasMaxLength(13);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Username)
                    .HasConstraintName("FK_Username");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .IsClustered(false);

                entity.ToTable("Inventory");

                entity.HasIndex(e => e.ProductId, "IFK_ProductId");

                entity.HasIndex(e => e.StoreId, "IFK_StoreId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_StoreId");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.StoreId, e.ProductId })
                    .IsClustered(false);

                entity.ToTable("Order");

                entity.HasIndex(e => e.CustomerId, "IFK_Order_CustomerId");

                entity.HasIndex(e => e.ProductId, "IFK_Order_ProductId");

                entity.HasIndex(e => e.StoreId, "IFK_Order_StoreId");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("smallmoney");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Order_CustomerId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Order_ProductId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Order_StoreId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.TypeId, "IFK_TypeId");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UnitPrice).HasColumnType("smallmoney");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TypeId");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ContactNumber).HasMaxLength(13);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Type");

                entity.Property(e => e.Type1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
