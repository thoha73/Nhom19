using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Books
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public BookCategoryRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<BookCategory> CreateBookCategory(BookCategory bookCategory)
        {
            using(var context= _contextFactory.CreateDbContext())
            {
                context.BookCategory.Add(bookCategory);
                await context.SaveChangesAsync();
                return bookCategory;
            }
        }

        public async Task<BookCategory> UpdateBookCategory(BookCategory bookCategory)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.BookCategory.Update(bookCategory);
                await context.SaveChangesAsync();
                return bookCategory;
            }
        }
    }
}
