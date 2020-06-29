using ClassRoom.Models;
using ClassRoom.Models.TransferModels;

namespace ClassRoom.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserTransferModel Login(LoginModel login);
    }
}
