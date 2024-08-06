﻿using FinancialPlan.Entity.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialPlan.Entity.Entities
{
    public class UserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
    }
}
