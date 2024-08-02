using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class TermConfig : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Terms");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.TermName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(t => t.Duration)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.StartDate)
                .IsRequired();

            builder.Property(t => t.EndDate)
                .IsRequired();

            builder.Property(t => t.PlanDueDate)
                .IsRequired();

            builder.Property(t => t.ReportDueDate)
                .IsRequired();

            builder.Property(t => t.Status)
                .HasMaxLength(50)
                .HasDefaultValue("New");

            builder.HasMany(t => t.FinancialPlans)
                .WithOne(f => f.Term)
                .HasForeignKey(f => f.TermId);

            builder.HasMany(t => t.MonthlyExpenseReports)
                .WithOne(m => m.Term)
                .HasForeignKey(m => m.TermId);
        }
    }
}
