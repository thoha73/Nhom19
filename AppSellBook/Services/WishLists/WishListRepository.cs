using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.WishLists
{
    public class WishListRepository : IWishListRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public WishListRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<WishList> CreateWishList(WishList wishList)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.WishLists.Add(wishList);
                await context.SaveChangesAsync();
                return wishList;
            }
        }

        public async Task<WishList> GetWishListByUserId(int userId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.WishLists.FirstOrDefaultAsync(w => w.userId == userId);
            }
        }
        public async Task<IEnumerable<WishList>> GetAllWishListForUser(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {

                return await context.WishLists.Include(w => w.bookWishLists)
                                              .ThenInclude(bw => bw.book)
                                              .ThenInclude(b => b.images)
                                              .Include(w => w.bookWishLists)
                                              .ThenInclude(bw => bw.book)
                                              .ThenInclude(b => b.author) 
                                              .Where(w => w.userId == userId)
                                              .ToListAsync();
            }
        }
    }
}
