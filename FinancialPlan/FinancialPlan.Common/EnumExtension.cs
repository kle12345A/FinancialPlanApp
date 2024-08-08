namespace FinancialPlan.Common
{
    public enum Position
    {
        FinancialExecutive,
        ProjectManager,
        OfficeAssistant,
        SeniorExecutive,
        AccountingExecutive,
        JuniorExecutive,
        Intern
    }

    public enum CostType
    {
        DirectCosts,
        IndirectCosts,
        AdministrationCosts,
        OperatingCosts,
        MaintenanceCosts,
        ManufacturingCosts
    }

    public enum ExpenseStatus
    {
        New,
        WaitingForApproval,
        Approved,
        Closed
    }

    public enum PlanStatus
    {
        New,
        WaitingForApproval,
        Approved,
        Denied
    }

    public enum TermStatus
    {
        New,
        InProgress,
        Closed
    }

    public enum Duration
    {
        Monthly,
        Quarterly,
        HalfYear
    }
}
