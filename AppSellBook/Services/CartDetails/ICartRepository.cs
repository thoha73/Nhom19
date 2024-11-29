using AppSellBook.Entities;

namespace AppSellBook.Services.CartDetails
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserId(int userId);
        Task<Cart> CreateCard(Cart cart);
<<<<<<< HEAD

=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    }
}
