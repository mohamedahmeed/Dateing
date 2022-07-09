using AutoMapper;
using Dateing.extinatino;
using Dateing.Models;
using System.Linq;

namespace Dateing.VM
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, MemberVm>()
                .ForMember(d=>d.PhotoUrl,op=>op.MapFrom(
                 s=>s.Photos.FirstOrDefault(s=>s.IsMain).Url))
                .ForMember(d=>d.Age,op=>op.MapFrom(s=>s.DateOfBirth.calcAge()))
                ;
            CreateMap<Photo, PhotoVm>();

        }
    }
}
