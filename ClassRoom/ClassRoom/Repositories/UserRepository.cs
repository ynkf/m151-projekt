using ClassRoom.Models;
using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ClassRoomContext _context;
        public UserRepository(ClassRoomContext context)
        {
            _context = context;
        }

        public bool Login(LoginModel login)
        {
            var result = _context.User.FirstOrDefault(u => 
                u.Email == login.Email 
                && u.Password == login.Password);

            return result != null;
        }
    }
}
