using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Models.DTO;
using FinancialPlan.Repository.Infrastructures;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

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
                                     ReportDetails = new List<AnnualReportDetailDTO>()
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
                                     ReportDetails = new List<AnnualReportDetailDTO>()
                                 }).ToListAsync();

            foreach (var report in reports)
            {
                var reportDetails = await (from fp in GetQuery()
                                           join u in _context.Users on fp.UploadedBy equals u.Id
                                           join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                           from department in departments.DefaultIfEmpty()
                                           where fp.UploadedDate.Year == report.Year
                                           group new { fp, department } by new { department.DepartmentName, fp.CostType } into detailGroup
                                           select new AnnualReportDetailDTO
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

        public async Task<IEnumerable<AnnualReportDetailDTO>> GetAnnualReportDetailsByDepartmentAsync(int year, string departmentName)
        {
            var reportDetails = await (from fp in GetQuery()
                                       join u in _context.Users on fp.UploadedBy equals u.Id
                                       join d in _context.Departments on u.DepartmentId equals d.Id into departments
                                       from department in departments.DefaultIfEmpty()
                                       where fp.UploadedDate.Year == year && department.DepartmentName.Contains(departmentName)
                                       group new { fp, department } by new { department.DepartmentName, fp.CostType } into detailGroup
                                       select new AnnualReportDetailDTO
                                       {
                                           Department = detailGroup.Key.DepartmentName,
                                           TotalExpense = detailGroup.Sum(x => x.fp.Total),
                                           BiggestExpenditure = detailGroup.Max(x => x.fp.Total),
                                           CostType = detailGroup.Key.CostType.ToString()
                                       }).OrderBy(dto => dto.Department).ToListAsync();
            return reportDetails;
        }

        public async Task<byte[]> ExportAnnualExpenseReportAsync(int year)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var reportDetails = await (from fp in _context.FinancialPlans
                                       join u in _context.Users on fp.UploadedBy equals u.Id
                                       join d in _context.Departments on u.DepartmentId equals d.Id
                                       where fp.UploadedDate.Year == year
                                       group new { fp, d } by new { d.DepartmentName, fp.CostType } into detailGroup
                                       select new AnnualReportDetailDTO
                                       {
                                           Department = detailGroup.Key.DepartmentName,
                                           TotalExpense = detailGroup.Sum(x => x.fp.Total),
                                           BiggestExpenditure = detailGroup.Max(x => x.fp.Total),
                                           CostType = detailGroup.Key.CostType.ToString()
                                       }).OrderBy(dto => dto.Department).ToListAsync();

            if (reportDetails == null || !reportDetails.Any())
            {
                return null;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add($"Annual Report {year}");

                worksheet.Cells[1, 1].Value = "Department";
                worksheet.Cells[1, 2].Value = "Total Expense";
                worksheet.Cells[1, 3].Value = "Biggest Expenditure";
                worksheet.Cells[1, 4].Value = "Cost Type";

                using (var range = worksheet.Cells[1, 1, 1, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                    range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                }

                int row = 2;
                foreach (var detail in reportDetails)
                {
                    worksheet.Cells[row, 1].Value = detail.Department;
                    worksheet.Cells[row, 2].Value = detail.TotalExpense;
                    worksheet.Cells[row, 3].Value = detail.BiggestExpenditure;
                    worksheet.Cells[row, 4].Value = detail.CostType;
                    worksheet.Cells[row, 2].Style.Numberformat.Format = "#,##0.00 \"VND\"";
                    worksheet.Cells[row, 3].Style.Numberformat.Format = "#,##0.00 \"VND\"";
                    row++;
                }

                using (var range = worksheet.Cells[2, 1, row - 1, 4])
                {
                    range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                    range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                    range.Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }


    }
}
