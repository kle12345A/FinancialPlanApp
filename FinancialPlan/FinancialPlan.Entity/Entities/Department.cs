using FinancialPlan.Entity.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class Department : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string DepartmentName { get; set; }
        public ICollection<User> Users { get; set; }
        public virtual ICollection<FinancialPlans> FinancialPlans { get; set; }
        public virtual ICollection<MonthlyExpenseReport> MonthlyExpenseReports { get; set; }
    }
}
