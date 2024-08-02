using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configurations
{
    public class AnnualReportDetailConfig : IEntityTypeConfiguration<AnnualReportDetail>
    {
        public void Configure(EntityTypeBuilder<AnnualReportDetail> builder)
        {
            // Table name
            builder.ToTable("AnnualReportDetails");

            // Primary key
            builder.HasKey(ard => ard.Id);

            // Properties configuration
            builder.Property(ard => ard.AnnualReportId)
                .IsRequired();

            builder.Property(ard => ard.DepartmentId)
                .IsRequired();

            builder.Property(ard => ard.TotalExpense)
                .IsRequired();

            builder.Property(ard => ard.BiggestExpenditure)
                .IsRequired();

            builder.Property(ard => ard.CostType)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ard => ard.Note)
                .HasMaxLength(255);

            // Relationships configuration
            builder.HasOne(ard => ard.AnnualReport)
                .WithMany(ar => ar.AnnualReportDetails)
                .HasForeignKey(ard => ard.AnnualReportId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ard => ard.Department)
                .WithMany() // Assuming Department does not have a collection for AnnualReportDetail
                .HasForeignKey(ard => ard.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
