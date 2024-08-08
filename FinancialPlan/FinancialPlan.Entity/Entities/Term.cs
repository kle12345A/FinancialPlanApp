using FinancialPlan.Entity.Entities.Base;

namespace FinancialPlan.Entity.Entities
{
    public class Term : BaseEntity
    {
        public string TermName { get; set; }
        public Duration Duration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime PlanDueDate { get; set; }
        public DateTime ReportDueDate { get; set; }
        public TermStatus Status { get; set; } = TermStatus.New;
        public ICollection<FinancialPlans> FinancialPlans { get; set; }
    }
}
