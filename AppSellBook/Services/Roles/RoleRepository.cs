using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Roles
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public RoleRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Role> GetRoleById(int id)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return  await context.Roles.FirstOrDefaultAsync(r=>r.roleId==id);

            }
        }
    }
}
