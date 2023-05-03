using LogisticCompany.DataAccess.Concrete.Configuration.Base;
using LogisticCompany.Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.DataAccess.Concrete.Configuration.Entity
{
    public class StatusConfiguration : BaseEntityConfiguration<Status>
    {
        public override void EntityConfigure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        }
    }
}
