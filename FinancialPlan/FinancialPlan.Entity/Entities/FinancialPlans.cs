using FinancialPlan.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
    public class FinancialPlans : BaseEntity
    {
        public Guid? TermId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }



        public Guid? DepartmentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Version { get; set; } = 1;

        [Required]
        public DateTime UploadedDate { get; set; } = DateTime.Now;

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
        public virtual Department Department { get; set; }
        public virtual Term Term { get; set; } // Sửa lỗi tại đây
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<PlanHistory> PlanHistories { get; set; }
    }
}
