using FinancialPlan.Entity.Entities.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class Expense : BaseEntity
    {
        public Guid? PlanId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ExpenseName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CostType { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public decimal? Total { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProjectName { get; set; }

        [Required]
        [MaxLength(255)]
        public string SupplierName { get; set; }

        [Required]
        [MaxLength(255)]
        public string PIC { get; set; }

        public string Note { get; set; }

        [Required]
        [MaxLength(50)]
        [DefaultValue("New")]
        public string ExpenseStatus { get; set; } = "New";

        // UserId
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual FinancialPlans FinancialPlan { get; set; }
    }

}
