using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(ClassRoomContext context) : base(context)
        {
        }

        public Exam GetExam(int examId)
        {
            return set.First(e => e.Id == examId);
        }

        public List<Exam> GetExames(Teacher teacher)
        {
            return set.Where(e =>
                teacher.Classes
                    .Select(c => c.Id)
                    .Contains(e.ClassId))
            .ToList();
        }

        public List<Exam> GetExames(ClassStudent classStudent)
        {
            return set.Where(e => e.ClassId == classStudent.ClassId).ToList();
        }
    }
}
