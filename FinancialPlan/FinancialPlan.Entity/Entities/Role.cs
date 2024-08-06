using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Entity.Entities
{
   public class Role : IdentityRole<Guid>
    {
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
