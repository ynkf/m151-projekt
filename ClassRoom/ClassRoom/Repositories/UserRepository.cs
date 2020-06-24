using ClassRoom.Models;
using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(ClassRoomContext context) : base(context)
        {
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
