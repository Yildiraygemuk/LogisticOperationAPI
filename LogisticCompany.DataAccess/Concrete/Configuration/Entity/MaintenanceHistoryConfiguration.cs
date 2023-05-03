using LogisticCompany.DataAccess.Concrete.Configuration.Base;
using LogisticCompany.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticCompany.DataAccess.Concrete.Configuration.Entity
{
    public class MaintenanceHistoryConfiguration : BaseEntityConfiguration<MaintenanceHistory>
    {
        public override void EntityConfigure(EntityTypeBuilder<MaintenanceHistory> builder)
        {
            builder.Property(x => x.MaintenanceId).IsRequired();
            builder.Property(x => x.ActionTypeId).IsRequired();

            builder.HasOne(x => x.Maintenance)
                .WithMany(x => x.MaintenanceHistories)
                .HasForeignKey(x => x.MaintenanceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ActionType)
                .WithMany(x=> x.MaintenanceHistories)
                .HasForeignKey(x => x.ActionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
