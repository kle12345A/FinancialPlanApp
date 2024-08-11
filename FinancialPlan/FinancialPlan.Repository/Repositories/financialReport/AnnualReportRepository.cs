using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;
using FinancialPlan.Repository.Infrastructures;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlan.Repository.Repositories.financialReport
{
    public class AnnualReportRepository : BaseRepository<FinancialPlans>, IAnnualReportRepository
    {
        private readonly FinancialPlanDbContext _context;

        public AnnualReportRepository(FinancialPlanDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AnnualReportDTO>> GetAllAnnualReportsAsync()
        {
            var reports = await (from fp in GetQuery()
                                 join u in _context.Users on fp.UploadedBy equals u.Id
                                 join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                 from department in departments.DefaultIfEmpty()
                                 group new { fp, department } by fp.UploadedDate.Year into annualGroup
                                 select new AnnualReportDTO
                                 {
                                     Year = annualGroup.Key,
                                     TotalExpense = annualGroup.Sum(x => x.fp.Total),
                                     TotalDepartment = annualGroup.Select(x => x.department.Id).Distinct().Count(),
                                     CreatedDate = new DateTime(annualGroup.Key, 12, 20),
                                     TotalTerm = annualGroup.Select(x => x.fp.TermId).Distinct().Count(),
                                     ReportDetails = new List<ReportDetailDTO>()
                                 }).OrderByDescending(x => x.Year).ToListAsync();
            return reports;
        }

        public async Task<IEnumerable<AnnualReportDTO>> GetAnnualReportsByYearAsync(int year)
        {
            var reports = await (from fp in GetQuery()
                                 join u in _context.Users on fp.UploadedBy equals u.Id
                                 join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                 from department in departments.DefaultIfEmpty()
                                 where fp.UploadedDate.Year == year
                                 group new { fp, department } by fp.UploadedDate.Year into annualGroup
                                 select new AnnualReportDTO
                                 {
                                     Year = annualGroup.Key,
                                     TotalExpense = annualGroup.Sum(x => x.fp.Total),
                                     TotalDepartment = annualGroup.Select(x => x.department.Id).Distinct().Count(),
                                     CreatedDate = new DateTime(annualGroup.Key, 12, 20),
                                     TotalTerm = annualGroup.Select(x => x.fp.TermId).Distinct().Count(),
                                     ReportDetails = new List<ReportDetailDTO>()
                                 }).ToListAsync();

            foreach (var report in reports)
            {
                var reportDetails = await (from fp in GetQuery()
                                           join u in _context.Users on fp.UploadedBy equals u.Id
                                           join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                           from department in departments.DefaultIfEmpty()
                                           where fp.UploadedDate.Year == report.Year
                                           group new { fp, department } by new { department.DepartmentName, fp.CostType } into detailGroup
                                           select new ReportDetailDTO
                                           {
                                               Department = detailGroup.Key.DepartmentName,
                                               TotalExpense = detailGroup.Sum(x => x.fp.Total),
                                               BiggestExpenditure = detailGroup.Max(x => x.fp.Total),
                                               CostType = detailGroup.Key.CostType.ToString()
                                           }).OrderBy(dto => dto.Department).ToListAsync();

                report.ReportDetails = reportDetails;
            }
            return reports;
        }

        public async Task<IEnumerable<ReportDetailDTO>> GetAnnualReportDetailsByDepartmentAsync(int year, string departmentName)
        {
            var reportDetails = await (from fp in GetQuery()
                                       join u in _context.Users on fp.UploadedBy equals u.Id
                                       join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                       from department in departments.DefaultIfEmpty()
                                       where fp.UploadedDate.Year == year && department.DepartmentName.Contains(departmentName)
                                       group new { fp, department } by new { department.DepartmentName, fp.CostType } into detailGroup
                                       select new ReportDetailDTO
                                       {
                                           Department = detailGroup.Key.DepartmentName,
                                           TotalExpense = detailGroup.Sum(x => x.fp.Total),
                                           BiggestExpenditure = detailGroup.Max(x => x.fp.Total),
                                           CostType = detailGroup.Key.CostType.ToString()
                                       }).OrderBy(dto => dto.Department).ToListAsync();
            return reportDetails;
        }
    }
}
