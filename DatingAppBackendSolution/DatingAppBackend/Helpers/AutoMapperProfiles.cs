using AutoMapper;
using DatingAppBackend.Extensions;

namespace DatingAppBackend.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<Models.Photo, DTOs.PhotoDto>();

      CreateMap<Models.AppUser, DTOs.MemberDto>()
        .ForMember(dst => dst.Age, o =>
          o.MapFrom(s => s.DateOfBirth.CalculateAge()))
        .ForMember(dst => dst.PhotoUrl, o =>
          o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));
    }
  }
}
