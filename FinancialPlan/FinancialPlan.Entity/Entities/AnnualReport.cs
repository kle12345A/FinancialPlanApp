using FinancialPlan.Entity.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class AnnualReport : BaseEntity
    {
        [Required]
        public int Year { get; set; }

        [Required]
        [MaxLength(255)]
        public string ReportName { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public int TotalTerms { get; set; }

        [Required]
        public int TotalDepartments { get; set; }

        [Required]
        public decimal TotalExpense { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }

        public virtual ICollection<AnnualReportDetail> AnnualReportDetails { get; set; } = new HashSet<AnnualReportDetail>();
    }
}
