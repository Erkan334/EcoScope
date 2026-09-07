using EcoScope.Dtos.UserDTOs;

namespace EcoScope.Services.UserServices
{
    public interface IUserService
    {
        public Task UpdateUserName(UpdateUserNameDto dto, int userId);
    }
}
