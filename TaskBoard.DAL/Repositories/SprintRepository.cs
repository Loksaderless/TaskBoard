using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.DAL.Repositories
{
    public class SprintRepository : ISprintRepository
    {
        private readonly ApplicationDbContext _db;

        public SprintRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<SprintEntity> GetAll()
        {
            return _db.Sprints.ToList();
        }

        public async Task<SprintEntity> GetByIdSprint(int id)
        {
            return await _db.Sprints.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Create(SprintEntity entity)
        {
            await _db.Sprints.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(SprintEntity entity)
        {
            _db.Sprints.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(SprintEntity entity)
        {
            _db.Sprints.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IEnumerable<int> GetProjectId()
        {
            return _db.Projects.Select(x => x.Id).ToList();
        }

        public IEnumerable<string> GetUsersLogin()
        {
            return _db.Users.Select(x => x.Login).ToList();
        }

        public async Task<User> GetLoginUser(string login)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}
