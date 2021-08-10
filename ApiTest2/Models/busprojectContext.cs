using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiTest2.Models
{
    public partial class busprojectContext : DbContext
    {
        public busprojectContext()
        {
        }

        public busprojectContext(DbContextOptions<busprojectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Bus> Bus { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Refund> Refund { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Seat> Seat { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=GUESSWHO;Database=busproject;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__admin__566AFA9A0CE0FBD9");

                entity.ToTable("admin");

                entity.Property(e => e.AId)
                    .HasColumnName("a_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.APassword)
                    .IsRequired()
                    .HasColumnName("a_password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasColumnName("contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.Property(e => e.BookingId)
                    .HasColumnName("booking_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookingStatus).HasColumnName("booking_status");

                entity.Property(e => e.CurrentCount).HasColumnName("current_count");

                entity.Property(e => e.CustomerContact)
                    .IsRequired()
                    .HasColumnName("customer_contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasColumnName("customer_email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasColumnName("customer_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FareAmount).HasColumnName("fare_amount");

                entity.Property(e => e.Feedback)
                    .IsRequired()
                    .HasColumnName("feedback")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumberOfSeats).HasColumnName("number_of_seats");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.Property(e => e.ScheduleId).HasColumnName("schedule_id");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_fk2");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("booking_fk0");
            });

            modelBuilder.Entity<Bus>(entity =>
            {
                entity.ToTable("bus");

                entity.Property(e => e.BusId)
                    .HasColumnName("bus_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusNumber).HasColumnName("bus_number");

                entity.Property(e => e.BusPlateNumber).HasColumnName("bus_plate_number");

                entity.Property(e => e.BusType).HasColumnName("bus_type");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.RouteId).HasColumnName("route_id");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Bus)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("bus_fk0");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("DRIVER");

                entity.Property(e => e.DriverId)
                    .HasColumnName("driver_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DriverContact)
                    .IsRequired()
                    .HasColumnName("driver_contact")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DriverName)
                    .IsRequired()
                    .HasColumnName("driver_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Driver)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DRIVER_fk0");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payment");

                entity.Property(e => e.PaymentId)
                    .HasColumnName("payment_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");

                entity.Property(e => e.PaymentDateTime)
                    .HasColumnName("payment_date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Refund>(entity =>
            {
                entity.ToTable("refund");

                entity.Property(e => e.RefundId)
                    .HasColumnName("refund_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PaymentId).HasColumnName("payment_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_bookingid");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Refund)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("refund_fk0");
            });

            modelBuilder.Entity<Routes>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK_ROUTES");

                entity.ToTable("routes");

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasColumnName("destination")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartingPoint)
                    .IsRequired()
                    .HasColumnName("starting_point")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("schedule_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BusId).HasColumnName("bus_id");

                entity.Property(e => e.DriverId).HasColumnName("driver_id");

                entity.Property(e => e.EstimatedArrivalTime).HasColumnName("estimated_arrival_time");

                entity.Property(e => e.FareAmount).HasColumnName("fare_amount");

                entity.Property(e => e.FromDate)
                    .HasColumnName("from_date")
                    .HasColumnType("date");

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasColumnName("remarks")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.ToDate)
                    .HasColumnName("to_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.BusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_fk0");

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.Schedule)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("schedule_fk1");
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.SeatNo)
                    .HasName("PK_SEAT");

                entity.ToTable("seat");

                entity.Property(e => e.SeatNo)
                    .HasColumnName("seat_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BusId).HasColumnName("bus_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Seat)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("seat_fk0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountStatus).HasColumnName("ACCOUNT_STATUS");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNo)
                    .IsRequired()
                    .HasColumnName("CONTACT_NO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Deposit).HasColumnName("deposit");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasColumnName("EMAIL_ADDRESS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("FULL_NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("GENDER")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("datetime");

                entity.Property(e => e.Userpassword)
                    .IsRequired()
                    .HasColumnName("USERPASSWORD")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
