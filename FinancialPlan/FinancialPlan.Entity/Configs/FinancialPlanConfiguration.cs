using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class FinancialPlanConfiguration : IEntityTypeConfiguration<FinancialPlans>
    {
        public void Configure(EntityTypeBuilder<FinancialPlans> builder)
        {
            builder.HasKey(fp => fp.Id);

            builder.HasOne(fp => fp.Term)
                   .WithMany(t => t.FinancialPlans)
                   .HasForeignKey(fp => fp.TermId)
                   .OnDelete(DeleteBehavior.Restrict); 

            builder.HasOne(fp => fp.User)
                   .WithMany(u => u.FinancialPlans)
                   .HasForeignKey(fp => fp.UploadedBy)
                   .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
