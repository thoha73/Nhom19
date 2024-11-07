using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Books
{
    
    public class BookRepository : IBookRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public BookRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Book> CreateBook(Book book)
        {
            using(BookDBContext content= _contextFactory.CreateDbContext())
            {
                content.Books.Add(book);
                await content.SaveChangesAsync();
                return book;
            }
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                Book book = new Book()
                {
                    bookId = bookId,
                };
                context.Books.Remove(book);
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c=>c.images)
                                          .ToListAsync();
            }
        }

        public async Task<Book> GetBookById(int bookId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c => c.images)
                                           .FirstOrDefaultAsync(r => r.bookId == bookId);
            }
        }

        public async Task<Book> UpdateBook(Book book)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext()) { 
                context.Books.Update(book);
                await context.SaveChangesAsync();
                return book;
            }
        }
    }
}
