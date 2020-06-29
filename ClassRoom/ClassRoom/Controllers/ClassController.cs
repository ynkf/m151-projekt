using AutoMapper;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ClassRoom.Controllers
{
    public class ClassController : ClassRoomControllerBase
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(
            IMapper mapper,
            IClassRepository classRepository
        ) {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        [HttpGet("class/teacher/{teacherId}")]
        public ActionResult GetClassesOfTeacher(int teacherId)
        {
            var res = _mapper.Map<List<Class>, List<ClassTransferModel>>(_classRepository.GetClassesOfTeacher(teacherId));

            return Ok(res);
        }
    }
}
