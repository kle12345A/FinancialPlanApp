using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class ReportDetailConfig : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.ToTable("ReportDetails");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Expense)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.CostType)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.UnitPrice)
                .IsRequired();

            builder.Property(r => r.Amount)
                .IsRequired();

            builder.Property(r => r.ProjectName)
                .HasMaxLength(255);

            builder.Property(r => r.SupplierName)
                .HasMaxLength(255);

            builder.Property(r => r.PIC)
                .HasMaxLength(255);

            builder.Property(r => r.Note)
                .HasMaxLength(255);

            builder.HasOne(r => r.MonthlyExpenseReport)
                .WithMany(m => m.ReportDetails)
                .HasForeignKey(r => r.ReportID);

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}
