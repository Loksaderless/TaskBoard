using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Interfaces
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
        Task<TaskEntity> GetByIdTask(int id);

        IEnumerable<int> GetSprintId();

        IEnumerable<string> GetUsersLogin();
    }
}
