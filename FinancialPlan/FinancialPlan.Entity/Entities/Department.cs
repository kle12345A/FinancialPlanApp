using FinancialPlan.Entity.Entities.Base;

namespace FinancialPlan.Entity.Entities
{
    public class Department : BaseEntity
    {
        public string DepartmentName { get; set; }
        public User User { get; set; }
    }
}
