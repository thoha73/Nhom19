using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.CartDetails
{
    public class CartDetailRepository : ICartDetailRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public CartDetailRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    
        public async Task<IEnumerable<CartDetail>> GetBooksInCart(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
               return await context.CartDetails.Include(b=>b.book)
                                                .ThenInclude(i=>i.images)
                                                .Where(c=>c.cart.userId==userId)
                                                .AsNoTracking().ToListAsync();
            }
        }
    }
}
