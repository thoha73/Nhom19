using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Roles
{
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public RoleUserRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<RoleUser> CreateRoleUser(RoleUser roleUser)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                context.RoleUser.Add(roleUser);
                await context.SaveChangesAsync();
                return roleUser;
            }
        }
    }
}
