using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByIdUser(int id);

        Task<User> GetByLoginUser(string login);
    }
}
