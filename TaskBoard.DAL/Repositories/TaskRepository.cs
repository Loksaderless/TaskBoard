using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _db.Tasks.ToList();
        }

        public async Task<TaskEntity> GetByIdTask(int id)
        {
            return await _db.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Create(TaskEntity entity)
        {
            await _db.Tasks.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(TaskEntity entity)
        {
            _db.Tasks.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(TaskEntity entity)
        {
            _db.Tasks.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public IEnumerable<int> GetSprintId()
        {
            return _db.Sprints.Select(x => x.Id).ToList();
        }

        public IEnumerable<string> GetUsersLogin()
        {
            return _db.Users.Select(x => x.Login).ToList();
        }
    }
}
