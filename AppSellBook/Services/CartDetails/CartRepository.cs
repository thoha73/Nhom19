using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.CartDetails
{
    public class CartRepository : ICartRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public CartRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Cart> CreateCard(Cart cart)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Carts.Add(cart);
                await context.SaveChangesAsync();
                return cart;
            }
        }

        public async Task<Cart> GetCartByUserId(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Carts.Include(r=>r.cartDetails).ThenInclude(b=>b.book).FirstOrDefaultAsync(c => c.userId == userId);
            }
        }
    }
}
