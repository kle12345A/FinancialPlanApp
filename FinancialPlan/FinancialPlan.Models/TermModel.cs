using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Models
{
    public class TermModel
    {
        public Guid Id { get; set; }
        public string TermName { get; set; }
        public Duration Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PlanDueDate { get; set; }
        public DateTime ReportDueDate { get; set; }
        public TermStatus Status { get; set; } = TermStatus.New;
        public ICollection<FinancialPlansModel> FinancialPlans { get; set; } 
    }
}
