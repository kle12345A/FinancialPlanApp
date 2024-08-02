using FinancialPlan.Entity.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class ReportHistory : BaseEntity
    {
        public Guid ReportID { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        [MaxLength(255)]
        public string UploadedFile { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string UploadedBy { get; set; }

        // UserId (optional)
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual MonthlyExpenseReport MonthlyExpenseReport { get; set; }
    }

}
