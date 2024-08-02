using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class PlanHistoryConfig : IEntityTypeConfiguration<PlanHistory>
    {
        public void Configure(EntityTypeBuilder<PlanHistory> builder)
        {
            builder.ToTable("PlanHistories");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Version)
                .IsRequired();

            builder.Property(p => p.UploadedDate)
                .IsRequired();

            builder.Property(p => p.UploadedBy)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.FileName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.FinancialPlan)
                .WithMany(f => f.PlanHistories)
                .HasForeignKey(p => p.PlanId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
