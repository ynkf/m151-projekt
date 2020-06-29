using AutoMapper;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;

namespace ClassRoom
{
    public class ClassRoomMappingProfile : Profile
    {
        public ClassRoomMappingProfile()
        {
            CreateMap<User, UserTransferModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => UserTypes.User));

            CreateMap<Student, UserTransferModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => UserTypes.Student));

            CreateMap<Teacher, UserTransferModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => UserTypes.Teacher));

            CreateMap<Class, ClassTransferModel>();

            CreateMap<Exam, ExamTransferModel>();

            CreateMap<Student, StudentMarkTransferModel>()
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName));
        }
    }
}
