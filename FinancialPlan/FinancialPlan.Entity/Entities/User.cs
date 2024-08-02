using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialPlan.Entity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }

        public string Status { get; set; }
        public string Notes { get; set; }

        public Guid PositionId { get; set; }
        public Position Position { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
