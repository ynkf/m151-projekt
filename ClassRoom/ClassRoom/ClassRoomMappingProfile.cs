using AutoMapper;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;

namespace ClassRoom
{
    public class ClassRoomMappingProfile : Profile
    {
        public ClassRoomMappingProfile()
        {
            CreateMap<Student, StudentTransferModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
        }
    }
}
