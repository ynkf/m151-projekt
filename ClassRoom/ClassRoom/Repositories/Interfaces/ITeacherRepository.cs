using ClassRoom.Models.Db;

namespace ClassRoom.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Teacher GetTeacher(int userId);
    }
}
