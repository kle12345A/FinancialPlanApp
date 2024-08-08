using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace FinancialPlan.Entity.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public Guid DepartmentId { get; set; }
        public Position Position { get; set; }
        public Guid Role { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; } = true;
        public string Notes { get; set; }
        public Department Department { get; set; }
        public ICollection<FinancialPlans> FinancialPlans { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
