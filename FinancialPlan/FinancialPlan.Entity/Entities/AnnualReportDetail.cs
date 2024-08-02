﻿using FinancialPlan.Entity.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Entity.Entities
{
    public class AnnualReportDetail : BaseEntity
    {
        [Required]
        public Guid AnnualReportId { get; set; }

        public virtual AnnualReport AnnualReport { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [Required]
        public decimal TotalExpense { get; set; }

        [Required]
        public decimal BiggestExpenditure { get; set; }

        [Required]
        [MaxLength(255)]
        public string CostType { get; set; }

        [MaxLength(255)]
        public string Note { get; set; }
    }
}