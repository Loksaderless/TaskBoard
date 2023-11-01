using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users.ToList();
        }

        public async Task<User> GetByIdUser(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByLoginUser(string login)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<bool> Create(User entity)
        {
            await _db.Users.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
