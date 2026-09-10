using EcoScope.Data;
using EcoScope.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<User>> GetAllAsync()
        {
            return context.Users.ToList();
        }

        public async Task<User?> GetByIdAsync(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
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
