using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
using EcoScope.Result;

namespace EcoScope.Services.UserServices
{
    public interface IUserService
    {
        public Task<ResultResponse> UpdateUserName(UpdateUserNameDto dto, int userId);

        public Task<DataResult<UserDto>> GetUserById(int userId);

        public Task<List<UserDto>> GetAllUsers();

        
    }
}
