using FinancialPlan.Entity.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class ReportDetail : BaseEntity
    {
        public Guid ReportID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Expense { get; set; }

        [Required]
        [MaxLength(255)]
        public string CostType { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public int Amount { get; set; }

        public decimal? Total { get; set; }

        [MaxLength(255)]
        public string ProjectName { get; set; }

        [MaxLength(255)]
        public string SupplierName { get; set; }

        [MaxLength(255)]
        public string PIC { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        // UserId (optional)
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual MonthlyExpenseReport MonthlyExpenseReport { get; set; }
    }

}
