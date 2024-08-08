using FinancialPlan.Entity.Contexts;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Repository.Infrastructures;
using FinancialPlan.Service.Service.financialplans;
using FinancialPlan.Service.Service.term;
using FinancialPlan.Service.Service.financialReport;
using FinancialPlan.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinancialPlan.Repository.Repositories.financialReport;
using FinancialPlan.Repository.Repositories.department;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddDbContext<FinancialPlanDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FinancialPlanDB")));

// Settings CORS
services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

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

services.AddScoped<IAnnualReportRepository, AnnualReportRepository>();


builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IFinancialPlanService, FinancialPlanService>();
builder.Services.AddScoped<ITermService, TermService>();
builder.Services.AddScoped<IAnnualReportService, AnnualReportService>();

builder.Services.AddAutoMapper(typeof(Program));

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

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
