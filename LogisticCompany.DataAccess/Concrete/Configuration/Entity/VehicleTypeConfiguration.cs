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
    public class VehicleTypeConfiguration : BaseEntityConfiguration<VehicleType>
    {
        public override void EntityConfigure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Vehicles)
                   .WithOne(x => x.VehicleType)
                   .HasForeignKey(x => x.VehicleTypeID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
