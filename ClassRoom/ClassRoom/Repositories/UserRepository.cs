using AutoMapper;
using ClassRoom.Models;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ClassRoomContext _classRoomContext;
        private readonly IMapper _mapper;

        public UserRepository(
            ClassRoomContext context,
            IMapper mapper
        ) : base(context)
        {
            _classRoomContext = context;
            _mapper = mapper;
        }

        public UserTransferModel Login(LoginModel login)
        {
            var user = set.FirstOrDefault(u => 
                u.Email == login.Email 
                && u.Password == login.Password);

            if (user == null)
            {
                return null;
            }

            var student = _classRoomContext.Student.FirstOrDefault(s => s.UserId == user.Id);

            if (student != null)
            {
                return _mapper.Map<Student, UserTransferModel>(student);
            }

            var teacher = _classRoomContext.Teacher.FirstOrDefault(t => t.UserId == user.Id);

            if (teacher != null)
            {
                return _mapper.Map<Teacher, UserTransferModel>(teacher);
            }

            return _mapper.Map<User, UserTransferModel>(user);
        }
    }
}
