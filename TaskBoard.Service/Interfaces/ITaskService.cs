using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;

namespace TaskBoard.Service.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskEntity>> GetAsync();

        Task<bool> CreateAsync(TaskDTO sprintModel);

        Task<bool> UpdateAsync(TaskDTO sprintModel);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<int>> GetAllSprintIdAsync();

        Task<IEnumerable<string>> GetAllUsersLoginAsync();
    }
}
