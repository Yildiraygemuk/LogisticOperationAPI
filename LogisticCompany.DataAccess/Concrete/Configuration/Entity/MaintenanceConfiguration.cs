using LogisticCompany.DataAccess.Concrete.Configuration.Base;
using LogisticCompany.Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.DataAccess.Concrete.Configuration.Entity
{
    public class MaintenanceConfiguration : BaseEntityConfiguration<Maintenance>
    {
        public override void EntityConfigure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(255).IsRequired();
            builder.Property(x => x.LocationLatitude).HasMaxLength(20);
            builder.Property(x => x.LocationLongitude).HasMaxLength(20);
            builder.Property(x => x.ExceptedTimeToFix).HasColumnType("date");

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Maintenances)
                .HasForeignKey(x => x.VehicleID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Maintenances)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Status)
                .WithMany(x => x.Maintenances)
                .HasForeignKey(x => x.StatusID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.PictureGroup)
                .WithMany(x => x.Maintenances)
                .HasForeignKey(x => x.PictureGroupID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
