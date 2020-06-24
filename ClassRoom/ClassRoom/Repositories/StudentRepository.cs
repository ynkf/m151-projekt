using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(ClassRoomContext context) : base(context)
        {
        }

        public Student GetStudent(int userId)
        {
            return set
                .Include(s => s.User)
                .FirstOrDefault(s => s.UserId == userId);
        }
    }
}
