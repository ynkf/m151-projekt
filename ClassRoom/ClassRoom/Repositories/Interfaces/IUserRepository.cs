using ClassRoom.Models;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool Login(LoginModel login);
    }
}
