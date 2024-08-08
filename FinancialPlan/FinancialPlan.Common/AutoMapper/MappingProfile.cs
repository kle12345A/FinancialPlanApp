using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
