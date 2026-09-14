using EcoScope.Dtos.UserDTOs;
using EcoScope.Models;
using EcoScope.Repositories.UserRepositories;
using EcoScope.Result;
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


        public async Task<List<UserDto>> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email

            }).ToList();
        }

        public async Task<DataResult<UserDto>> GetUserById(int userId)
        {
            var user = await userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                return new DataResult<UserDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "User could not be found"
                };
            }

            var userData = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return new DataResult<UserDto>
            {
                IsSuccess = true,
                Data = userData,
                Message = null
            };
        }


        public async Task<ResultResponse> UpdateUserName(UpdateUserNameDto dto, int userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "User could not be found"
                };
                

            }

            user.Name = dto.Name;

            //UpdateAsync also saves the operation
            var result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new ResultResponse
                {
                    IsSuccess = false,
                    Message = "Could not update user"
                };
            }


            return new ResultResponse
            {
                IsSuccess = true,
                Message = "Name updated successfully"
            };
        }

        

        
    }
}
