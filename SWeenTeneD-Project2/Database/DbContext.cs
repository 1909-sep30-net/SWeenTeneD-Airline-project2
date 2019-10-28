using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data.Common;
using System.Data.SqlClient;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql.EntityFrameworkCore;
using Database;

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
        public virtual DbSet<FlightLocation> FlightLocation { get; set; }
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
        }
    }

}
