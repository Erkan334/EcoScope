using EcoScope.Data;
using EcoScope.Models;

namespace EcoScope.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EcoScopeDbContext context;

        public UserRepository(EcoScopeDbContext _context)
        {
            context = _context;
        }

        public void Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public Task<User> UpdateAsync(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
