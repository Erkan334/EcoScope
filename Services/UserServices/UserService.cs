using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
using EcoScope.Repositories.UserRepositories;
using Microsoft.AspNetCore.Identity;

namespace EcoScope.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly UserManager<User> userManager;
        public UserService(UserManager<User> _userManager, IUserRepository _userRepository)
        {

            userRepository = _userRepository;
            userManager = _userManager;
        }

        public async Task UpdateUserName(UpdateUserNameDto dto, int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new Exception();
            }

            user.Name = dto.Name;

            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                throw new Exception();
            }

            await userRepository.SaveAsync();
        }

        public async Task<User?> GetUserById(int userId) 
        {
            var user = await userRepository.GetByIdAsync(userId);

            if(user == null) 
            {
                throw new Exception();
            }

            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();

            return users;
        }
    }
}
