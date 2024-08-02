

using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using FinancialPlan.Service.Service.expense;
using FinancialPlan.Service.Service.financialplans;
using FinancialPlan.Service.Service.monthlyexpens;
using FinancialPlan.Service.Service.planhistory;
using FinancialPlan.Service.Service.position;
using FinancialPlan.Service.Service.reportdetail;
using FinancialPlan.Service.Service.reporthistory;
using FinancialPlan.Service.Service.term;
using FinancialPlan.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddDbContext<FinancialPlanDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialPlanDB")));

builder.Services.AddIdentity<User, Role>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<FinancialPlanDbContext>()
  .AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IFinancialPlanService, FinancialPlanService>();
builder.Services.AddScoped<IMonthlyExpenseReportService, MonthlyExpenseReportService>();
builder.Services.AddScoped<IPlanHistoryService, PlanHistoryService>();
builder.Services.AddScoped<IPositionService, PositionService>();
builder.Services.AddScoped<IReportDetailService, ReportDetailService>();
builder.Services.AddScoped<IReportHistoryService, ReportHistoryService>();
builder.Services.AddScoped<ITermService, TermService>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
services.AddAuthorization();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
