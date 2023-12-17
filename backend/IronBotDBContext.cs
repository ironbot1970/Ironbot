using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace irobotservice.Models
{
    public partial class IronBotDBContext : DbContext
    {
        public IronBotDBContext()
        {
        }

        public IronBotDBContext(DbContextOptions<IronBotDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BillingAddress> BillingAddresses { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<Robot> Robots { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4");

            modelBuilder.Entity<BillingAddress>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Vatnumber)
                    .HasMaxLength(20)
                    .HasColumnName("VATNumber");

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.HasIndex(e => e.RobotId, "RobotId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Robot)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cart_ibfk_1");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.ImageUrl).HasMaxLength(250);

                entity.Property(e => e.IsDeleted)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("0: Vacuum cleaner, 1: Drone, ..., 1000: Other");
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasIndex(e => e.RobotId, "RobotId");

                entity.HasIndex(e => e.UserId, "UserId");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.IsDepositPaid)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsDepositRefunded)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsRentalTotalAmountPaid)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.RentalDeposit).HasPrecision(10);

                entity.Property(e => e.RentalFee).HasPrecision(10);

                entity.Property(e => e.RentalGroup)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasComment("Generated from timestamp, should be the same on records in one rental transaction");

                entity.Property(e => e.RentalTotalAmount).HasPrecision(10);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status).HasComment("0: Open, 1: Closed, 2: Cancelled");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Robot)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rentals_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rentals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Rentals_ibfk_1");
            });

            modelBuilder.Entity<Robot>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "CategoryId");

                entity.Property(e => e.Deposit).HasPrecision(10);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhotoUrl).HasMaxLength(250);

                entity.Property(e => e.RentalFee).HasPrecision(10);

                entity.Property(e => e.Status).HasComment("0: Available, 1: OutOfOrder, 2: NotAvailable, 3: Retired");

                entity.Property(e => e.ThumbnailUrl).HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Robots)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Robots_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.BillingAddressId, "BillingAddressId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsAdmin)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsValidated)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("MD5 hashed pswd");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("MD5 hash-salt");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Status).HasComment("0: Validating, 1: Enabled, 2: Deleted");

                entity.Property(e => e.TimeStamp)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ValidationUrl)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("Users_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
