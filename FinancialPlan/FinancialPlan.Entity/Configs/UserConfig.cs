using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FinancialPlan.Entity.Entities;

namespace FinancialPlan.Entity.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(u => u.FullName)
                .HasMaxLength(255);

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.Property(u => u.Address)
                .HasMaxLength(255);

           

            builder.Property(u => u.Status)
                .HasMaxLength(50);

            builder.Property(u => u.Notes)
                .HasMaxLength(255);

            builder.Property(u => u.PositionId)
                .IsRequired();

            builder.HasOne(u => u.Position)
                .WithMany()
                .HasForeignKey(u => u.PositionId);
            builder.HasOne(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId);
        }
    }
}
