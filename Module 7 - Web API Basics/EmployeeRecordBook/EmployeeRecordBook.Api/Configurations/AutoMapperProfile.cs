using AutoMapper;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.ViewModels;

namespace EmployeeRecordBook.Api.Configurations
{
   public class AutoMapperProfile : Profile
   {
      public AutoMapperProfile()
      {
         CreateMap<EmployeeVm, Employee>();
      }
   }
}
