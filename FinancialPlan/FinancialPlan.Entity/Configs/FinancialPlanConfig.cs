using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class FinancialPlansConfig : IEntityTypeConfiguration<FinancialPlans>
    {
        public void Configure(EntityTypeBuilder<FinancialPlans> builder)
        {
            builder.ToTable("FinancialPlans");

            builder.HasKey(f => f.Id);

            builder.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.TermId)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(f => f.UploadedDate)
                .IsRequired();

            builder.Property(f => f.UploadedBy)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(f => f.Term)
                .WithMany(t => t.FinancialPlans)
                .HasForeignKey(f => f.TermId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Expenses)
                .WithOne(e => e.FinancialPlan)
                .HasForeignKey(e => e.PlanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(f => f.Department)
                .WithMany(d => d.FinancialPlans)
                .HasForeignKey(f => f.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
