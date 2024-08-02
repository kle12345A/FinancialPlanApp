using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class MonthlyExpenseReportConfig : IEntityTypeConfiguration<MonthlyExpenseReport>
    {
        public void Configure(EntityTypeBuilder<MonthlyExpenseReport> builder)
        {
            builder.ToTable("MonthlyExpenseReports");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.ReportName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(m => m.Month)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.UploadDate)
                .IsRequired();

            builder.Property(m => m.DueDate)
                .IsRequired();

            builder.Property(m => m.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Version)
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasOne(m => m.Department)
                .WithMany(d => d.MonthlyExpenseReports)
                .HasForeignKey(m => m.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);  

            builder.HasOne(m => m.Term)
                .WithMany(t => t.MonthlyExpenseReports)
                .HasForeignKey(m => m.TermId)
                .OnDelete(DeleteBehavior.Cascade);  

            builder.HasMany(m => m.ReportDetails)
                .WithOne(r => r.MonthlyExpenseReport)
                .HasForeignKey(r => r.ReportID)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(m => m.ReportHistories)
                .WithOne(r => r.MonthlyExpenseReport)
                .HasForeignKey(r => r.ReportID)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(m => m.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
