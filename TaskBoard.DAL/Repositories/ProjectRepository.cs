using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<ProjectEntity> GetAll()
        {
            return _db.Projects.ToList();
        }

        public async Task<ProjectEntity> GetByIdProject(int id)
        {
            return await _db.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Create(ProjectEntity entity)
        {
            await _db.Projects.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(ProjectEntity entity)
        {
            _db.Projects.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(ProjectEntity entity)
        {
            _db.Projects.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
