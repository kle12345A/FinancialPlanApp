using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class ExpenseConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.ExpenseName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.CostType)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.UnitPrice)
                .IsRequired();

            builder.Property(e => e.Amount)
                .IsRequired();

            builder.Property(e => e.ProjectName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.SupplierName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.PIC)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.ExpenseStatus)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("New");

            builder.HasOne(e => e.FinancialPlan)
                .WithMany(f => f.Expenses)
                .HasForeignKey(e => e.PlanId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
