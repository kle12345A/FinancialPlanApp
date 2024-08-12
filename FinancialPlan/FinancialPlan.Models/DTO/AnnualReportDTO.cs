namespace FinancialPlan.Models.DTO
{
    public class AnnualReportDTO
    {
        public int Year { get; set; }
        public decimal TotalExpense { get; set; }
        public int TotalDepartment { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalTerm { get; set; } 
        public List<AnnualReportDetailDTO> ReportDetails { get; set; }
    }

    public class AnnualReportDetailDTO
    {
        public string Department { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal BiggestExpenditure { get; set; }
        public string CostType { get; set; } 
    }
}
