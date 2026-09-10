using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;

namespace EcoScope.Services.UserServices
{
    public interface IUserService
    {
        public Task UpdateUserName(UpdateUserNameDto dto, int userId);

        public Task<User?> GetUserById(int userId);

        public Task<List<User>> GetAllUsers();

        
    }
}
