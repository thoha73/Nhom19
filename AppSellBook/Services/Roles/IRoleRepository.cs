using AppSellBook.Entities;

namespace AppSellBook.Services.Roles
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleById(int id);
    }
}
