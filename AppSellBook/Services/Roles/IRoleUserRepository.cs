using AppSellBook.Entities;

namespace AppSellBook.Services.Roles
{
    public interface IRoleUserRepository
    {
        Task<RoleUser> CreateRoleUser(RoleUser roleUser);
    }
}
