using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClassRoom.Controllers
{
    public class ExamController : ClassRoomControllerBase
    {
        private readonly IExamRepository _repository;

        public ExamController(IExamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("exam/teacher/class/{classId}")]
        public ActionResult GetTeacherExams(int classId)
        {
            return Ok(_repository.GetTeacherExames(classId));
        }

        [HttpGet("exam/teacher/exam/{examId}")]
        public ActionResult GetTeacherExamStudents(int examId)
        {
            return Ok(_repository.GetTeacherExamStudents(examId));
        }

        [HttpGet("exam/student/{studentId}")]
        public ActionResult GetStudentExams(int studentId)
        {
            return Ok(_repository.GetStudentExams(studentId));
        }

        [HttpPost("exam/teacher/exam/{examId}")]
        public ActionResult UpdateTeacherExamStudents(int examId, List<StudentMarkTransferModel> studentMarkTransferModel)
        {
            _repository.UpdateMarks(examId, studentMarkTransferModel);

            return Ok();
        }
    }
}
