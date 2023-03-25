using API.Dtos;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<CreateSecretDto,Secret>();
      CreateMap<Secret,CreateSecretDto>();
      CreateMap<Secret,SecretDto>();
    }
  }
}