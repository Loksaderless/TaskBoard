using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Helpers;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository userRepository;

        public AccountService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetLoginUser(UserDTO userModel)
        {
            var user = new User()
            {
                Login = userModel.Login
            };

            return await userRepository.GetByLoginUser(user.Login);
        }

        public async Task<bool> Register(UserDTO userModel)
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

        public async Task<string> Authorization(User userModel)
        {
            var user = new User()
            {
                Login = userModel.Login,
                Password = userModel.Password,
                Role = userModel.Role
            };

            var userToken = CreateJwt(user);

            return userToken;
        }

        public async Task<string> UpdatePassword(UserDTO userModel)
        {
            Random rnd = new Random();

            var userObj = new User()
            {
                Login = userModel.Login,
            };

            var user = await userRepository.GetByLoginUser(userObj.Login);

            string passwordNew = rnd.Next(10000, 99999).ToString();

            user.Password = HashHelpers.HashPasswordCode(passwordNew);

            await userRepository.Update(user);

            return passwordNew;
        }

        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("super protection ... and not only");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
