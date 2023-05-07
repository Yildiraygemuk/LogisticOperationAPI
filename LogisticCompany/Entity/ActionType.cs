using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class ActionType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
    }
}
