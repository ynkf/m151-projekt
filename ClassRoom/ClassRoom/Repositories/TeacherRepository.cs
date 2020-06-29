using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ClassRoomContext context) : base(context)
        {
        }

        public Teacher GetTeacher(int userId)
        {
            return set
                .Include(s => s.User)
                .FirstOrDefault(s => s.UserId == userId);
        }
    }
}
