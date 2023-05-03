using LogisticCompany.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.DataAccess.Concrete.Contexts
{
    public class LogisticContext:DbContext
    {
        public LogisticContext(DbContextOptions<LogisticContext> options) : base(options) { }

        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<PictureGroup> PictureGroups { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MaintenanceHistory> MaintenanceHistories { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Maintenance>().ToTable("Maintenance");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<PictureGroup>().ToTable("PictureGroup");
            modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<MaintenanceHistory>().ToTable("MaintenanceHistory");
            modelBuilder.Entity<ActionType>().ToTable("ActionType");
        }
    }
}
