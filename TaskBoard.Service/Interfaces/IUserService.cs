using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;

namespace TaskBoard.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAsync();

        Task<User> GetLoginUser(UserDTO userModel);

        Task<bool> CreateAsync(UserDTO userModel);

        Task<bool> UpdateRoleAsync(UserDTO userModel);

        Task<bool> DeleteAsync(int id);
    }
}
