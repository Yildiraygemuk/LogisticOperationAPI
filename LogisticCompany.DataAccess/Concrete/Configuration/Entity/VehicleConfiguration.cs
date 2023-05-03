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
    public class VehicleConfiguration : BaseEntityConfiguration<Vehicle>
    {
        public override void EntityConfigure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(x => x.PlateNo).HasMaxLength(60).IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Vehicles)
                   .HasForeignKey(x => x.UserID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.VehicleType)
                   .WithMany(x => x.Vehicles)
                   .HasForeignKey(x => x.VehicleTypeID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
