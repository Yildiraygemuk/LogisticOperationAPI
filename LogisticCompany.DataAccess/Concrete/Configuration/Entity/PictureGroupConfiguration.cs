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
    public class PictureGroupConfiguration : BaseEntityConfiguration<PictureGroup>
    {
        public override void EntityConfigure(EntityTypeBuilder<PictureGroup> builder)
        {
            builder.Property(x => x.PictureImage).HasColumnType("text");

        }
    }
}
