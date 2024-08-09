using AutoMapper;
using FinancialPlan.Entity.Entities;
using FinancialPlan.Models;

namespace FinancialPlan.Common.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FinancialPlans, FinancialPlansModel>();
            CreateMap<Term, TermModel>();
            CreateMap<Role, RoleModel>();
            CreateMap<Department, DepartmentModel>();
            CreateMap<User, UserModel>();
        }
    }
}
