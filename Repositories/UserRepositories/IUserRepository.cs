using EcoScope.Models;

namespace EcoScope.Repositories.UserRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int userId);

        Task<bool> ExistByEmailAsync(string email);

        void Delete(int userId);

        Task SaveAsync();
    }
}
