using AppSellBook.Entities;

namespace AppSellBook.Services
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthor();
    }
}
