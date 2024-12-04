using AppSellBook.Entities;

namespace AppSellBook.Services.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUser();
        Task<User> GetUserByName(string userName);
        Task<User> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> UpdateUser2(User user);
        Task<bool> DeleteUser(int userId);
        Task<User> UpdatePass(User user);
        Task<bool> UpdatePoint(User user);
    }
}
