using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.WishLists
{
    public class BookWishListRepository : IBookWishListRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public BookWishListRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<BookWishList> CreateBookWishList(BookWishList bookWishList)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                context.BookWishList.Add(bookWishList);
                await context.SaveChangesAsync();
                return bookWishList;
            }
        }

        public async Task<bool> existsInBookWishList(int wishListId, int bookId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                
                return await context.BookWishList.AnyAsync(r =>r.wishListswishListId==wishListId&&r.booksbookId==bookId);
            }
        }
    }
}
