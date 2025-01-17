using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.User;

namespace OnlineShop.Service.Users
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

    public class UserService: IUserService
    {
        private readonly ShopContext _context;

        public UserService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.users.Where(x=>x.IsDeleted==false).ToListAsync();
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
            var person = await _context.users.FindAsync(user.Id);
            if (person != null)
            {
                var UserViewModel = new EditViewModel
                {
                    Id= person.Id,
                    FullName= person.FullName,
                    Email= person.Email,
                    Password= person.Password
                };
              
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user != null && user.IsDeleted==false)
            {
                var DeleteUser = new EditViewModel
                {
                    IsDeleted=user.IsDeleted=true
                };
               
            }
            await _context.SaveChangesAsync();
        } 
    }
  
}
