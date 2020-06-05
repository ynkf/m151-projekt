using ClassRoom.Models;
using ClassRoom.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoom.Controllers
{
    public class UserController : ClassRoomControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("user/login")]
        public ActionResult Login(LoginModel login)
        {
            return Ok(_repository.Login(login));
        }
    }
}
