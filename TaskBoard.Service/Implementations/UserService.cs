using TaskBoard.Service.Interfaces;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Helpers;
using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = userRepository.GetAll();

            return users;
        }

        public async Task<User> GetLoginUser(UserDTO userModel)
        {
            var user = new User()
            {
                Login = userModel.Login
            };

            return await userRepository.GetByLoginUser(user.Login);
        }

        public async Task<bool> CreateAsync(UserDTO userModel)
        {
            var user = new User()
            {
                Login = userModel.Login,
                Password = HashHelpers.HashPasswordCode(userModel.Password),
                Codeword = HashHelpers.HashPasswordCode(userModel.Codeword),
                Role = "User"
            };

            await userRepository.Create(user);

            return true;
        }

        public async Task<bool> UpdateRoleAsync(UserDTO userModel)
        {
            var userObj = new User()
            {
                Id = userModel.Id
            };

            var user = await userRepository.GetByIdUser(userObj.Id);
            if (user == null)
                return false;

            if (userModel.Role != "User" &&
                userModel.Role != "Manager" &&
                userModel.Role != "Admin")
                return false;
            else
            {
                user.Role = userModel.Role;

                await userRepository.Update(user);

                return true;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await userRepository.GetByIdUser(id);

            if (user == null)
                return false;

            await userRepository.Delete(user);

            return true;
        }
    }
}
