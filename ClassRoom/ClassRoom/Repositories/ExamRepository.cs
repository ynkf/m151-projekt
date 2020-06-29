using AutoMapper;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClassRoom.Repositories
{
    public class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        private readonly ClassRoomContext _classRoomContext;
        private readonly IMapper _mapper;

        public ExamRepository(ClassRoomContext context, IMapper mapper) : base(context)
        {
            _classRoomContext = context;
            _mapper = mapper;
        }

        public List<ExamTransferModel> GetTeacherExames(int classId)
        {
            var exams = set
                .Include(e => e.Marks)
                .Where(e => e.ClassId == classId)
                .ToList();

            var examTransferModels = _mapper.Map<List<Exam>, List<ExamTransferModel>>(exams);

            return examTransferModels;
        }

        public List<StudentMarkTransferModel> GetTeacherExamStudents(int examId)
        {
            var studentMarkTransferModels = new List<StudentMarkTransferModel>();
            var exam = set.FirstOrDefault(e => e.Id == examId);

            if(exam != null)
            {
                var studentIds = _classRoomContext.ClassStudent
                    .Include(cs => cs.Student)
                    .Where(cs => cs.ClassId == exam.ClassId)
                    .Select(cs => cs.StudentId)
                    .ToList();

                var students = new List<Student>();

                studentIds.ForEach(id => students.Add(_classRoomContext.Student.Include(s => s.User).FirstOrDefault(s => s.Id == id)));

                studentMarkTransferModels = _mapper.Map<List<Student>, List<StudentMarkTransferModel>>(students);

                foreach (var student in studentMarkTransferModels)
                {
                    student.Mark = _classRoomContext.Mark.FirstOrDefault(m =>
                        m.ExamId == exam.Id && m.StudentId == student.StudentId)?.Mark1;
                }
            }

            return studentMarkTransferModels;
        }

        public void UpdateMarks(int examId, List<StudentMarkTransferModel> studentMarkTransferModels)
        {
            foreach(var student in studentMarkTransferModels)
            {
                var mark = _classRoomContext.Mark.FirstOrDefault(m => m.ExamId == examId && m.StudentId == student.StudentId);
                mark.Mark1 = student.Mark;
                _classRoomContext.SaveChanges();
            }
            
        }

        public List<StudentExamTransferModel> GetStudentExams(int studentId)
        {
            var studentExamTransferModels = new List<StudentExamTransferModel>();
            var student = _classRoomContext.Student
                .Include(s => s.User)
                .FirstOrDefault(s => s.Id == studentId);

            if (student != null)
            {
                var studentMarkTransferModel = _mapper.Map<Student, StudentMarkTransferModel>(student);
                var classId = _classRoomContext.ClassStudent.FirstOrDefault(cs => cs.StudentId == studentId)?.ClassId;
                if (classId != null)
                {
                    var exams = _classRoomContext.Exam
                        .Where(e => e.ClassId == classId)
                        .ToList();

                    var examTransferModels = _mapper.Map<List<Exam>, List<ExamTransferModel>>(exams);

                    foreach (var examTransferModel in examTransferModels)
                    {
                        var mark = _classRoomContext.Mark.FirstOrDefault(m => m.ExamId == examTransferModel.Id && m.StudentId == studentMarkTransferModel.StudentId)?.Mark1;
                        
                        var smTransferModel = new StudentMarkTransferModel { 
                            StudentId = studentMarkTransferModel.StudentId,
                            LastName = studentMarkTransferModel.LastName,
                            FirstName = studentMarkTransferModel.FirstName,
                            Mark = mark
                        };
                        
                        studentExamTransferModels.Add(new StudentExamTransferModel(examTransferModel, smTransferModel));
                    }
                }

            }

            return studentExamTransferModels;
        }
    }
}
