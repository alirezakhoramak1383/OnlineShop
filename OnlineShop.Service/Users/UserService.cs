using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Users;
using static OnlineShop.Service.Users.UserService;

namespace OnlineShop.Service.Users
{
    public class UserService: IUserService
    {
        private readonly ShopContext _context;

        public UserService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.users.FindAsync(id);
        }

        public async Task CreateUserAsync(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
        public interface IUserService
        {
            Task<List<User>> GetUsersAsync();
            Task<User> GetUserByIdAsync(int id);
            Task CreateUserAsync(User user);
            Task UpdateUserAsync(User user);
            Task DeleteUserAsync(int id);
        }
    }
}
