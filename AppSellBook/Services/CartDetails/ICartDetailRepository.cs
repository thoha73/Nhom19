using AppSellBook.Entities;

namespace AppSellBook.Services.CartDetails
{
    public interface ICartDetailRepository
    {
        Task<IEnumerable<CartDetail>> GetBooksInCart(int userId);
        Task<int> GetBookCountInCart(int userId);
        Task<CartDetail> CreateCartDetail(CartDetail cartDetail);
        Task<bool> existsInCart(int cartId, int bookId);

    }
}
