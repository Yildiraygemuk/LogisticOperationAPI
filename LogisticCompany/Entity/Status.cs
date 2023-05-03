using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
