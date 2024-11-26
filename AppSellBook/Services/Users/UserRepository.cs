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

        public async Task<User> GetUserByName(string userName)
        {
            using (BookDBContext content = _contextFactory.CreateDbContext())
            {
                return await content.Users.FirstOrDefaultAsync(r => r.username.Equals(userName));
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                var useExist= await context.Users.FindAsync(user.userId);
                if (useExist != null)
                {
                    //useExist.phone = user.phone;
                    //useExist.purchaseAddress = user.purchaseAddress;
                    //useExist.deliveryAddress = user.deliveryAddress;
                    //useExist.lastName = user.lastName;
                    //useExist.firstName = user.firstName;
                    //useExist.gender = user.gender;
                    //useExist.email = user.email;
                    //useExist.point = 0;
                    useExist.phone = useExist.phone == null ? user.phone : useExist.phone;
                    useExist.purchaseAddress = useExist.purchaseAddress == null ? user.purchaseAddress : useExist.purchaseAddress;
                    useExist.deliveryAddress = useExist.deliveryAddress == null ? user.deliveryAddress : useExist.deliveryAddress;
                    useExist.lastName = useExist.lastName == null ? user.lastName : useExist.lastName;
                    useExist.firstName = useExist.firstName == null ? user.firstName : useExist.firstName;
                    useExist.gender = useExist.gender == null ? user.gender : useExist.gender;
                    useExist.email = useExist.email == null ? user.email : useExist.email;
                }
                await context.SaveChangesAsync();
                return useExist;
            }
        }
    }
}
