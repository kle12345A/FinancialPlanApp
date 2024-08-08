using FinancialPlan.Entity.Entities.Base;

namespace FinancialPlan.Entity.Entities
{
    public class FinancialPlans : BaseEntity
    {
        public string FinancialPlanName { get; set; }
        public string FileReportName { get; set; }
        public Guid TermId { get; set; }
        public Guid UploadedBy { get; set; }
        public int Version { get; set; }
        public DateTime UploadedDate { get; set; }
        public PlanStatus Status { get; set; }
        public string Expense { get; set; }
        public CostType CostType { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public string ProjectName { get; set; }
        public string SupplierName { get; set; }
        public string PIC { get; set; }
        public string Notes { get; set; }
        public ExpenseStatus ExpenseStatus { get; set; }
        public Term Term { get; set; }
        public User User { get; set; }
    }
}
