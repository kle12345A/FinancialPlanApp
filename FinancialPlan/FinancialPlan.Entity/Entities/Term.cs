using FinancialPlan.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class Term : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string TermName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Duration { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public DateTime PlanDueDate { get; set; }

        [Required]
        public DateTime ReportDueDate { get; set; }

        [MaxLength(50)]
        [DefaultValue("New")]
        public string Status { get; set; } = "New";

        public virtual ICollection<FinancialPlans> FinancialPlans { get; set; }
        public virtual ICollection<MonthlyExpenseReport> MonthlyExpenseReports { get; set; }
    }
}
