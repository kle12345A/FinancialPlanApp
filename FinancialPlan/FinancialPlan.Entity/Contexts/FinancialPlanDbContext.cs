using FinancialPlan.Entity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlan.Entity.Contexts
{
    public class FinancialPlanDbContext : IdentityDbContext<User, Role, Guid>
    {
        public FinancialPlanDbContext() 
        {
        }
        public FinancialPlanDbContext(DbContextOptions<FinancialPlanDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FinancialPlans> FinancialPlans { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<MonthlyExpenseReport> MonthlyExpenseReports { get; set; }
        public virtual DbSet<PlanHistory> PlanHistories { get; set; }
        public virtual DbSet<ReportDetail> ReportDetails { get; set; }
        public virtual DbSet<ReportHistory> ReportHistories { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
                var sqlConnectionStr = configuration.GetConnectionString("FinancialPlanDB");
                optionsBuilder.UseSqlServer(sqlConnectionStr, config =>
                {
                    config.EnableRetryOnFailure();
                });
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialPlanDbContext).Assembly);
            //modelBuilder.SeedData();
        }
    }
}
