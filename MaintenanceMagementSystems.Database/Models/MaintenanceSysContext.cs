using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.ManyToMany;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class MaintenanceSysContext : DbContext
    {
        public MaintenanceSysContext(DbContextOptions<MaintenanceSysContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DbConnection");
            }
        }

        //Models
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }

        //lookup tables
        public DbSet<CancellationReason> CancelationReasons { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        //fluent api

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Beneficiary has multiple Ticket while the ticket has one Beneficiary
            modelBuilder.Entity<User>()
                .HasMany<Ticket>(t => t.BeneficiaryTickets)
                .WithOne(u => u.BeneficiaryUser)
                .HasForeignKey(t => t.BeneficiaryID)
                .OnDelete(DeleteBehavior.Restrict);


            //BackOffice has multiple ticket and every ticket connect with multi BackOffice
            modelBuilder.Entity<BackOfficesTickets>()
                .HasKey(bft => new { bft.BackOfficeId, bft.TicketId });

            modelBuilder.Entity<BackOfficesTickets>()
                .HasOne<Ticket>(t => t.ticket)
                .WithMany(t => t.backOfficesTickets)
                .HasForeignKey(t => t.TicketId);

            modelBuilder.Entity<BackOfficesTickets>()
                .HasOne<User>(u => u.user)
                .WithMany(u => u.BackOfficeTickets)
                .HasForeignKey(u => u.BackOfficeId);

            //the ticket has one ststus but a status has multiple tickets 
            modelBuilder.Entity<Ticket>()
                .HasOne<Status>(s => s.status)
                .WithMany(t => t.ticket)
                .HasForeignKey(s => s.StatusID);

            //every ticket should has one maintenance type while th once maintenance type has multiple tickets
            modelBuilder.Entity<Ticket>()
                .HasOne<MaintenanceType>(m => m.maintenanceType)
                .WithMany(t => t.tickets)
                .HasForeignKey(m => m.MaintenanceTypeID);

            //ticket has once floor while floor has multiple tickets
            modelBuilder.Entity<Ticket>()
                .HasOne<Floor>(f => f.floor)
                .WithMany(t => t.tickets)
                .HasForeignKey(f => f.FloorId);

            //ticket has clacelled reason while calncelled reason has multiple tickets
            modelBuilder.Entity<Ticket>()
                .HasOne<CancellationReason>(c => c.cancelationReason)
                .WithMany(t => t.tickets)
                .HasForeignKey(c => c.CancellationReasonID);

            //ticket can be rejected once time with user and this user can reject multi tickets
            modelBuilder.Entity<Ticket>()
                .HasOne<User>(u => u.UserRejected)
                .WithMany(t => t.TicketsRejected)
                .HasForeignKey(u => u.RejectedBy);

            //user has one role while every role assign to multi user
            modelBuilder.Entity<User>()
                .HasOne<UserRole>(ur => ur.userRole)
                .WithMany(u => u.users)
                .HasForeignKey(ur => ur.UserRoleId);

            //User should has one location while location (from floor table) can has multiple user
            modelBuilder.Entity<User>()
                .HasOne<Floor>(f => f.floor)
                .WithMany(u => u.users)
                .HasForeignKey(f => f.FloorId);

            //user maybe work in manintenance type and every maintenance type has multiple worker
            modelBuilder.Entity<User>()
                .HasOne<MaintenanceType>(mt => mt.maintenanceType)
                .WithMany(u => u.users)
                .HasForeignKey(mt => mt.MaintenanceTypeId);

            //floor should be in one bulding while the bulding has multi floors 
            modelBuilder.Entity<Floor>()
                .HasOne<Building>(b => b.building)
                .WithMany(f => f.floors)
                .HasForeignKey(b => b.BuildingId).IsRequired();

            //bulding should has city for address while one city can has multi buildings
            modelBuilder.Entity<Building>()
                .HasOne<City>(c => c.city)
                .WithMany(b => b.buildings)
                .HasForeignKey(c => c.CityId).IsRequired();

            //the bulding has one BuildingManager and also BuildingManager manager on one building
            modelBuilder.Entity<Building>()
                .HasOne<User>(u => u.UserbuildingManager)
                .WithMany()
                .HasForeignKey(u => u.BuildingManagerId)
                .IsRequired();

            //City has one Country while country has multi cities
            modelBuilder.Entity<City>()
               .HasOne<Country>(c => c.country)
               .WithMany(cun => cun.Cities)
               .HasForeignKey(c => c.CountryId).IsRequired();

            //User Roles
            modelBuilder.Entity<UserRole>()
                .HasMany<User>(u => u.users)
                .WithOne(u => u.userRole)
                .HasForeignKey(u => u.UserRoleId);
        }
    }


    public class SwcContextFactory : IDesignTimeDbContextFactory<MaintenanceSysContext>
    {
        public SwcContextFactory()
        {
        }

        private IConfiguration Configuration => new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public MaintenanceSysContext CreateDbContext(string[] args)
        {

            var builder = new DbContextOptionsBuilder<MaintenanceSysContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("DbConnection"));

            return new MaintenanceSysContext(builder.Options);
        }
    }

}
