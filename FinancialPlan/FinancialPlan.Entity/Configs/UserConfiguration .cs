using FinancialPlan.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialPlan.Entity.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Department)
                   .WithOne(d => d.User)
                   .HasForeignKey<User>(u => u.DepartmentId).OnDelete(DeleteBehavior.Cascade); ;

            builder.HasMany(u => u.FinancialPlans)
                   .WithOne(fp => fp.User)
                   .HasForeignKey(fp => fp.UploadedBy).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
