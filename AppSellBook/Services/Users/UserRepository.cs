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

        //public async Task<User> CreateUser(User user)
        //{
        //    using (BookDBContext context = _contextFactory.CreateDbContext())
        //    {
        //        context.Users.Add(user);
        //        try
        //        {
        //            await context.SaveChangesAsync();
        //        }catch(Exception ex)
        //        {
        //            throw new 
        //        }
        //        return user;
        //    }
        //}
        public async Task<User> CreateUser(User user)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Users.Add(user);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException dbEx)
                {
                    // Ghi log lỗi và thông báo inner exception
                    Console.WriteLine($"Database update error: {dbEx.Message}");
                    if (dbEx.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {dbEx.InnerException.Message}");
                    }
                    throw new Exception("Lỗi khi lưu người dùng vào cơ sở dữ liệu. Chi tiết: " + dbEx.Message, dbEx);
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi chung
                    Console.WriteLine($"System error: {ex.Message}");
                    throw new Exception("Lỗi hệ thống: " + ex.Message, ex);
                }

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
                return await content.Users.Include(r=>r.roleUsers).FirstOrDefaultAsync(r => r.username.Equals(userName));
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                var useExist= await context.Users.FindAsync(user.userId);
                if (useExist != null)
                {
                    useExist.phone = useExist.phone == null ? user.phone : useExist.phone;
                    useExist.purchaseAddress = useExist.purchaseAddress == null ? user.purchaseAddress : useExist.purchaseAddress;
                    useExist.deliveryAddress = useExist.deliveryAddress == null ? user.deliveryAddress : useExist.deliveryAddress;
                    useExist.dateOfBirth=useExist.dateOfBirth == null ? user.dateOfBirth : useExist.dateOfBirth;
                    useExist.lastName = useExist.lastName == null ? user.lastName : useExist.lastName;
                    useExist.firstName = useExist.firstName == null ? user.firstName : useExist.firstName;
                    useExist.gender = useExist.gender == null ? user.gender : useExist.gender;
                    useExist.email = useExist.email == null ? user.email : useExist.email;
                    useExist.point= useExist.point == null ?0 : useExist.point;
                }
                await context.SaveChangesAsync();
                return useExist;
            }
        }
        public async Task<User> UpdateUser2(User user)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var useExist = await context.Users.FindAsync(user.userId);
                if (useExist != null)
                {
                    useExist.phone = user.phone == null ? useExist.phone : user.phone;
                    useExist.purchaseAddress = user.purchaseAddress == null ? useExist.purchaseAddress : user.purchaseAddress;
                    useExist.deliveryAddress = user.deliveryAddress;
                    useExist.dateOfBirth = user.dateOfBirth;
                    useExist.lastName = user.lastName == null ? useExist.lastName : user.lastName;
                    useExist.firstName = user.firstName == null ? useExist.firstName : user.firstName;
                    useExist.gender = user.gender;
                    useExist.email = user.email;
                    useExist.point = user.point == null ? 0 : user.point;
                }
                context.Users.Update(useExist);
                await context.SaveChangesAsync();
                return user;
            }
        }
        public async Task<User> UpdatePassword(User user)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var useExist = await context.Users.FindAsync(user.userId);
                if (useExist != null)
                {
                    useExist.password = user.password;

                }
                await context.SaveChangesAsync();
                return useExist;
            }
        }
        public async Task<User> UpdatePass(User user)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var useExist = await context.Users.FindAsync(user.userId);
                if (useExist != null)
                {
                    useExist.password = user.password;
                }
                await context.SaveChangesAsync();
                return useExist;
            }
        }

        public async Task<bool> UpdatePoint(User user)
        {

                using (BookDBContext context = _contextFactory.CreateDbContext())
                {
                    var useExist = await context.Users.FindAsync(user.userId);
                    if (useExist != null)
                    { 
                        useExist.point = user.point;
                    }
                    context.Users.Update(useExist);
                    
                    return await context.SaveChangesAsync()>0;
            }
        }
    }
}
