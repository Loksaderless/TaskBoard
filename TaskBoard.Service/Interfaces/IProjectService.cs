using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;

namespace TaskBoard.Service.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectEntity>> GetAsync();

        Task<bool> CreateAsync(ProjectDTO projectModel);

        Task<bool> UpdateAsync(ProjectDTO projectModel);

        Task<bool> DeleteAsync(int id);
    }
}
