using LogisticCompany.Core.DataAccess.Concrete;
using LogisticCompany.Core.Helpers;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.DataAccess.Concrete.Contexts;
using LogisticCompany.Entity.Entity;

namespace LogisticCompany.DataAccess.Concrete.Repository
{
    public class MaintenanceRepository : GenericRepository<Maintenance>, IMaintenanceRepository
    {
        public MaintenanceRepository(LogisticContext context, IHttpAccessorHelper httpAccessorHelper) : base(context, httpAccessorHelper)
        {
        }
    }
}
