using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
