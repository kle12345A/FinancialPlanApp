namespace FinancialPlan.Models
{
    public class UserRoleModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
