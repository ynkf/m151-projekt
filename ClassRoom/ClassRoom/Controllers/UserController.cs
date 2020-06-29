using AutoMapper;
using ClassRoom.Models;
using ClassRoom.Models.Db;
using ClassRoom.Models.TransferModels;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace ClassRoom.Controllers
{
    public class UserController : ClassRoomControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public UserController(
            IMapper mapper,
            IUserRepository userRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository
        ) {
            _mapper = mapper;
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        [HttpPost("user/login")]
        public ActionResult Login(LoginModel login)
        {
            var userTransferModel = _userRepository.Login(login);

            if (userTransferModel == null)
            {
                return NoContent();
            }

            return Ok(userTransferModel);
        }
    }
}
