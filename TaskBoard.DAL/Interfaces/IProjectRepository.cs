using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Interfaces
{
    public interface IProjectRepository : IBaseRepository<ProjectEntity>
    {
        Task<ProjectEntity> GetByIdProject(int id);
    }
}
