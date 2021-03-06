﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data.Common;
using System.Data.SqlClient;

namespace Database
{
    public partial class SWTDbContext : DbContext
    {
        public SWTDbContext(){}
        public SWTDbContext(DbContextOptions<SWTDbContext> options)
                : base(options) { }

        public virtual DbSet<Customer> Customer { get; set;}
        public virtual DbSet<Airport> Airport { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightTicket> FlightTicket { get; set; }

        public virtual DbSet<Manager> Manager{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.CustomerID)
                    .UseIdentityColumn(1,1)
                    .IsRequired();

                entity.HasIndex(c => c.CustomerID)
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(e => e.Email)
                      .HasMaxLength(50);
                //%@% verified needed

                entity.Property(e => e.Password)
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Password)
                    .IsUnique();

            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.HasKey(e => e.Name);

                entity.Property(e => e.Name)
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Weather)
                    .IsRequired()
                    .HasMaxLength(10);

            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.Property(e => e.FlightID)
                    .UseIdentityColumn(1,1)
                    .IsRequired();

                entity.HasIndex(e => e.FlightID)
                    .IsUnique();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DepartureTime)
                    .IsRequired();

                entity.Property(e => e.ArrivalTime)
                    .IsRequired();

                entity.HasOne(e => e.Airport)
                    .WithMany(d => d.Flight)
                    .HasForeignKey(p => p.Origin)
                    .IsRequired();

                entity.HasOne(e => e.Airport)
                    .WithMany(d => d.Flight)
                    .HasForeignKey(p => p.Destination)
                    .IsRequired();

                entity.Property(e => e.SeatAvailable)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .IsRequired();
            });

            modelBuilder.Entity<FlightTicket>(entity => 
            {
                entity.Property(e => e.FlightTicketID)
                    .UseIdentityColumn(1,1)
                    .IsRequired();

                entity.HasIndex(e => e.FlightTicketID)
                    .IsUnique();

                entity.HasOne(e => e.Flight)
                    .WithMany(d => d.FlightTicket)
                    .HasForeignKey(p => p.FlightID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Customer)
                    .WithMany(d => d.FlightTicket)
                    .HasForeignKey(p => p.CustomerID)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Price)
                    .IsRequired();
                    
                entity.Property(e => e.Checkin)
                    .IsRequired();

                entity.Property(e => e.Luggage);
                    

            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.Property(c => c.ManagerId)
                    .UseIdentityColumn(1, 1)
                    .IsRequired();

                entity.HasIndex(c => c.ManagerId)
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(e => e.Email)
                      .HasMaxLength(50);
                //%@% verified needed

                entity.Property(e => e.Password)
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Password)
                    .IsUnique();


            });
        }
    }

}
