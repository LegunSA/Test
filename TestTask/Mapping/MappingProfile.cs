using AutoMapper;
using TestTask.Data.Entityes;
using TestTask.Model;

namespace TestTask.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<PatientModel, Patient>()
       .IncludeMembers(src => src.Name)
       .ForMember(model => model.Gender, opt => opt.MapFrom(entity => entity.Gender))
       .ForMember(model => model.BirthDate, opt => opt.MapFrom(entity => entity.BirthDate))
       .ForMember(model => model.Active, opt => opt.MapFrom(entity => entity.Active))
       .ReverseMap();

      CreateMap<Patient, NameModel>()
        .ForMember(model => model.Id, opt => opt.MapFrom(entity => entity.Id))
        .ForMember(model => model.Use, opt => opt.MapFrom(entity => entity.Use))
        .ForMember(model => model.Family, opt => opt.MapFrom(entity => entity.Family))
        .ForMember(model => model.Given, opt => opt.MapFrom(entity => entity.Given))
        .ReverseMap();
    }
  }
}
