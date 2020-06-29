using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using System.Collections.Generic;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IExamRepository
    {
        List<ExamTransferModel> GetTeacherExames(int classId);

        List<StudentMarkTransferModel> GetTeacherExamStudents(int examId);

        List<StudentExamTransferModel> GetStudentExams(int studentId);

        void UpdateMarks(int examId, List<StudentMarkTransferModel> studentMarkTransferModels);
    }
}
