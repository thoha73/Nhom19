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

        public async Task<CartDetail> CreateCartDetail(CartDetail cartDetail)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                context.CartDetails.Add(cartDetail);
                await context.SaveChangesAsync();
                return cartDetail;
            }
        }

        public async Task<bool> existsInCart(int cartId, int bookId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {

                return await context.CartDetails.AnyAsync(r => r.cartId == cartId && r.bookId == bookId);
            }
        }

        public async Task<int> GetBookCountInCart(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {

                return await context.CartDetails.Where(c=>c.cart.userId==userId).CountAsync();
            }
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
