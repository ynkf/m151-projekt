using ClassRoom.Models.Db;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Student GetStudent(int userId);
    }
}
