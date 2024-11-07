using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace AppSellBook.Services.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public UserRepository(IDbContextFactory<BookDBContext> dbContextFactory)
        {
            this._contextFactory = dbContextFactory;
        }

        public async Task<User> CreateUser(User user)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user;
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            using(BookDBContext context = _contextFactory.CreateDbContext())
            {
                User user = new User()
                {
                    userId = userId
                };
                context.Users.Remove(user);
                
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            using(BookDBContext content = _contextFactory.CreateDbContext())
            {
                return await content.Users.FirstOrDefaultAsync(r => r.userId == userId);
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
                return user;
            }
        }
    }
}
