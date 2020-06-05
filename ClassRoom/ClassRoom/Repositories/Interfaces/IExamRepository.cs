using ClassRoom.Models.Db;
using System.Collections.Generic;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IExamRepository
    {
        List<Exam> GetExames(Teacher teacher);

        List<Exam> GetExames(ClassStudent classStudent);

        Exam GetExam(int examId);
    }
}
