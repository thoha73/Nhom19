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
            try
            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    context.Books.Add(book);
                    await context.SaveChangesAsync();
                    return book;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu sách vào cơ sở dữ liệu.", ex);
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

        public async Task<bool> DeleteBooksAsync(List<int> bookIds)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var books = await context.Books.Where(b => bookIds.Contains(b.bookId)).ToListAsync();
                if (!books.Any())
                {
                    return false;
                }
                context.Books.RemoveRange(books);
                return await context.SaveChangesAsync() > 0;
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c => c.images)
                                          .Include(a=>a.author)
                                          .Include(c => c.categories).ToListAsync();
            }
        }

        public async Task<Book> GetBookById(int bookId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c => c.images)
                                            .Include(a=>a.author)
                                            .Include(c=>c.categories)
                                           .FirstOrDefaultAsync(r => r.bookId == bookId);
            }
        }

        public async Task<int> GetBookCount()
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Books.CountAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            using(BookDBContext context = _contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c => c.images).Include(c=>c.categories).Where(c=>c.categories.Any(b=>b.categoryId==categoryId)).ToListAsync();
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
