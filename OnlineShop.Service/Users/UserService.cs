using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Context;
using OnlineShop.Domin.Entities.Users;
using OnlineShop.Model.ViewModel.User;

namespace OnlineShop.Service.Users
{
    public interface IUserService
    {
        Task<List<UserViewModel>> GetUsersAsync();
        Task<UserViewModel> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserViewModel userviewModel);
        Task UpdateUserAsync(UserViewModel userViewMdel);
        Task DeleteUserAsync(int id);
    }

    public class UserService: IUserService
    {
        private readonly ShopContext _context;

        public UserService(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<UserViewModel>> GetUsersAsync()
        {
            return await _context.users.Where(x => x.IsDeleted == false).Select(s => new UserViewModel
            {
                Id = s.Id,
                FullName = s.FullName,
                Address = s.Address,
                Email = s.Email,
                Order = s.Order,
                Password = s.Password,
            }).ToListAsync();
        }

        public async Task<UserViewModel> GetUserByIdAsync(int id)
        {
            return await _context.users.Where(u=>u.Id==id && u.IsDeleted==false).Select(x=>new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Address = x.Address,
                Email = x.Email,
                Password = x.Password,
                Order=x.Order

            })
                .FirstOrDefaultAsync();
        }

        public async Task CreateUserAsync(UserViewModel userViewModel)
        {
            var user = new User()
            {
                FullName = userViewModel.FullName,
                Address = userViewModel.Address,
                Email = userViewModel.Email,
                Password = userViewModel.Password,
            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserViewModel userViewModel)
        {
            var person = await _context.users.FirstOrDefaultAsync(x=>x.Id== userViewModel.Id);
            if (person != null)
            {
                person.FullName = userViewModel.FullName;
                person.Email = userViewModel.Email;
                person.Password = userViewModel.Password;
                person.Address = userViewModel.Address;
                person.Order = userViewModel.Order;
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.users.FindAsync(id);

            user.IsDeleted = true;

            await _context.SaveChangesAsync();
        } 
    }
  
}
