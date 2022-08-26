using AutoMapper;
using EmployeeRecordBook.Core.Entities;
using EmployeeRecordBook.ViewModels;

namespace EmployeeRecordBook.Api.Configurations
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<EmployeeVm, Employee>();
      }
   }
}
