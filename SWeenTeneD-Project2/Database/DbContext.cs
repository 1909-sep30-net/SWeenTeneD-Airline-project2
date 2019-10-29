using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.CustomerID)
                    .UseIdentityColumn();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                      .IsRequired()
                      .HasMaxLength(30);

                entity.Property(e => e.Email)
                      .IsRequired();
                //%@% verified needed

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasIndex(e => e.Password)
                    .IsUnique();

            });

            modelBuilder.Entity<Airport>(entity =>
            {
                entity.Property(e => e.AirportID)
                    .UseIdentityColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

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
                    .UseIdentityColumn();

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DepartureTime)
                    .IsRequired();

                entity.Property(e => e.ArrivalTime)
                    .IsRequired();
            });


            modelBuilder.Entity<FlightTicket>(entity => 
            {
                entity.Property(e => e.TicketID)
                    .UseIdentityColumn();

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

        }
    }

}
