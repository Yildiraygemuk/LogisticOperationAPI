namespace LogisticCompany.Core.Entities.Concrete
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
