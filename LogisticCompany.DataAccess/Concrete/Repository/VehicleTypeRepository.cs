using LogisticCompany.Core.DataAccess.Concrete;
using LogisticCompany.Core.Helpers;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.DataAccess.Concrete.Contexts;
using LogisticCompany.Entity.Entity;

namespace LogisticCompany.DataAccess.Concrete.Repository
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(LogisticContext context, IHttpAccessorHelper httpAccessorHelper) : base(context, httpAccessorHelper)
        {
        }
    }
}
