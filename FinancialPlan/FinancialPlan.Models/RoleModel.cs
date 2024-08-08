using System.ComponentModel.DataAnnotations;

namespace FinancialPlan.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Description { get; set; }
        [Required]
        public bool IsActive { get; set; } = true;
        public ICollection<UserRoleModel> UserRoles { get; set; } 
    }
}
