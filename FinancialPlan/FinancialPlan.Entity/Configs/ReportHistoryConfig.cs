using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class ReportHistoryConfig : IEntityTypeConfiguration<ReportHistory>
    {
        public void Configure(EntityTypeBuilder<ReportHistory> builder)
        {
            builder.ToTable("ReportHistories");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Version)
                .IsRequired();

            builder.Property(r => r.UploadedFile)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.UploadedDate)
                .IsRequired();

            builder.Property(r => r.UploadedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(r => r.MonthlyExpenseReport)
                .WithMany(m => m.ReportHistories)
                .HasForeignKey(r => r.ReportID);

            builder.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);
        }
    }
}
