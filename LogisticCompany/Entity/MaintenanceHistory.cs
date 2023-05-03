using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class MaintenanceHistory : BaseEntity
    {
        public int MaintenanceId { get; set; }
        public int ActionTypeId { get; set; }
        public virtual Maintenance Maintenance { get; set; }
        public virtual ActionType ActionType { get; set; }
    }
}
