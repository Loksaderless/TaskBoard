using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;

namespace TaskBoard.Service.Interfaces
{
    public interface IAccountService
    {
        Task<User> GetLoginUser(UserDTO userModel);

        Task<bool> Register(UserDTO userModel);

        Task<string> Authorization(User userModel);

        Task<string> UpdatePassword(UserDTO userModel);
    }
}
