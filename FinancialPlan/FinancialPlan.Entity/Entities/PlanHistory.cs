using FinancialPlan.Entity.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class PlanHistory : BaseEntity
    {
        public Guid? PlanId { get; set; }

        [Required]
        public int Version { get; set; }

        [Required]
        public DateTime UploadedDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string UploadedBy { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; }

        // UserId
        public Guid? UserId { get; set; }
        public virtual User User { get; set; }

        // Navigation properties
        public virtual FinancialPlans FinancialPlan { get; set; }
    }

}
