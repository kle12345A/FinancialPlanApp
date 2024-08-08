using System.ComponentModel;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
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
        public DepartmentModel Department { get; set; } 
        public ICollection<FinancialPlansModel> FinancialPlans { get; set; }
        public ICollection<UserRoleModel> UserRoles { get; set; } 
    }
}
