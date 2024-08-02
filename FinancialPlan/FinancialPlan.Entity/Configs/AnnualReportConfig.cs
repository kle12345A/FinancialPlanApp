using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Entity.Configs
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using global::FinancialPlan.Entity.Entities;

    namespace FinancialPlan.Entity.Configurations
    {
        public class AnnualReportConfig : IEntityTypeConfiguration<AnnualReport>
        {
            public void Configure(EntityTypeBuilder<AnnualReport> builder)
            {
                builder.ToTable("AnnualReports");

                builder.HasKey(ar => ar.Id);

                builder.Property(ar => ar.Year)
                    .IsRequired();

                builder.Property(ar => ar.ReportName)
                    .IsRequired()
                    .HasMaxLength(255);

                builder.Property(ar => ar.CreatedDate)
                    .IsRequired();

                builder.Property(ar => ar.TotalTerms)
                    .IsRequired();

                builder.Property(ar => ar.TotalDepartments)
                    .IsRequired();

                builder.Property(ar => ar.TotalExpense)
                    .IsRequired();

                builder.Property(ar => ar.Note)
                    .HasMaxLength(255);

                builder.HasMany(ar => ar.AnnualReportDetails)
                    .WithOne(ard => ard.AnnualReport)
                    .HasForeignKey(ard => ard.AnnualReportId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }

}
