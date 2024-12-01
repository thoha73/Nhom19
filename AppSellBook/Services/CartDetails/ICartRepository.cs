using AppSellBook.Entities;

namespace AppSellBook.Services.CartDetails
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task<Cart> CreateCard(Cart cart);
    }
}
