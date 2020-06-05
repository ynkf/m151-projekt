using ClassRoom.Models.Db;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    public class ExamController : ClassRoomControllerBase
    {
        private readonly IExamRepository _repository;

        public ExamController(IExamRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("exam/teacher")]
        public ActionResult GetTeacherExams(Teacher teacher)
        {
            return Ok(_repository.GetExames(teacher));
        }
    }
}
