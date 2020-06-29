using AutoMapper;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClassRoom.Controllers
{
    public class StudentController : ClassRoomControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("student/{userId}")]
        public ActionResult GetStudent(int userId)
        {
            var res = _mapper.Map<Student, UserTransferModel>(_repository.GetStudent(userId));

            return Content(JsonConvert.SerializeObject(res));
        }
    }
}
