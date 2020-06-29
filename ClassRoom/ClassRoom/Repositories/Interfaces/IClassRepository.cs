using ClassRoom.Models.Db;
using System.Collections.Generic;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IClassRepository
    {
        List<Class> GetClassesOfTeacher(int teacherId);
    }
}
