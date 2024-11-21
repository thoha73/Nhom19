using AppSellBook.Entities;

namespace AppSellBook.Services.CartDetails
{
    public interface ICartDetailRepository
    {
        Task<IEnumerable<CartDetail>> GetBooksInCart(int userId);

    }
}
