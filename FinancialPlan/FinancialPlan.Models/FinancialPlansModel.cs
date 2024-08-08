using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Models
{
    public class FinancialPlansModel
    {
        public Guid Id { get; set; }
        public string FinancialPlanName { get; set; }
        public string FileReportName { get; set; }
        public Guid TermId { get; set; }
        public Guid UploadedBy { get; set; }
        public int Version { get; set; }
        public DateTime UploadedDate { get; set; }
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
        public TermModel Term { get; set; } 
        public UserModel User { get; set; } 
    }
}
