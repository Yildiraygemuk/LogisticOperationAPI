using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class PictureGroup : BaseEntity
    {
        public string PictureImage { get; set; } 
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
