using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Interfaces
{
    public interface ISprintRepository : IBaseRepository<SprintEntity>
    {
        Task<SprintEntity> GetByIdSprint(int id);

        IEnumerable<int> GetProjectId();

        IEnumerable<string> GetUsersLogin();

        Task<User> GetLoginUser(string login);
    }
}
