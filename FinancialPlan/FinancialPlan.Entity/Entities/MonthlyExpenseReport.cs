using FinancialPlan.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class MonthlyExpenseReport : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string ReportName { get; set; }

        public Guid? TermId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Month { get; set; }

        public Guid? DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UploadedBy { get; set; }

        [Required]
        public DateTime UploadDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Version { get; set; } = 1;

        // UserId
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; }
        public virtual Term Term { get; set; }
        public virtual ICollection<ReportDetail> ReportDetails { get; set; }
        public virtual ICollection<ReportHistory> ReportHistories { get; set; }
    }

}
