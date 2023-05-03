using LogisticCompany.Core.DataAccess.Concrete;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.DataAccess.Concrete.Contexts;
using LogisticCompany.Entity.Entity;

namespace LogisticCompany.DataAccess.Concrete.Repository
{
    public class PictureGroupRepository : GenericRepository<PictureGroup>, IPictureGroupRepository
    {
        public PictureGroupRepository(LogisticContext context) : base(context)
        {
        }
    }
}
