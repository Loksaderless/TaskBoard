using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;

namespace TaskBoard.Service.Interfaces
{
    public interface ISprintService
    {
        Task<IEnumerable<SprintEntity>> GetAsync();

        Task<bool> CreateAsync(SprintDTO sprintModel);

        Task<bool> UpdateAsync(SprintDTO sprintModel);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<int>> GetAllProjectIdAsync();

        Task<IEnumerable<string>> GetAllUsersLoginAsync();
    }
}
