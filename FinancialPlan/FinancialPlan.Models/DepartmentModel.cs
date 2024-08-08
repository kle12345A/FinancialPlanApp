namespace FinancialPlan.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public UserModel User { get; set; }
    }
}
