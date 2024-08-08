using FinancialPlan.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinancialPlan.Entity.Configs
{
    public class TermConfiguration : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasMany(t => t.FinancialPlans)
                   .WithOne(fp => fp.Term)
                   .HasForeignKey(fp => fp.TermId);
        }
    }
}
