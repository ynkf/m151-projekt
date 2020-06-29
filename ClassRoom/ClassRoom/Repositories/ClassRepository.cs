using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(ClassRoomContext context) : base(context)
        {
        }

        public List<Class> GetClassesOfTeacher(int teacherId)
        {
            return set
                .Where(c => c.TeacherId == teacherId)
                .ToList();
        }
    }
}
