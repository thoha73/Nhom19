using AppSellBook.Entities;
using AppSellBook.Schema.Results;
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
                                          .Include(c => c.bookCategories)
                                          .ThenInclude(bc => bc.category)
                                          .ToListAsync();
            }
        }

        public async Task<Book> GetBookById(int bookId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Books.Include(c => c.images)
                                            .Include(a=>a.author)
                                          .Include(c => c.bookCategories)
                                          .ThenInclude(bc => bc.category)
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
                return await context.Books
                            .Include(b => b.images)                      
                            .Include(b => b.bookCategories)               
                            .Where(b => b.bookCategories
                                .Any(bc => bc.categoriescategoryId == categoryId)) 
                            .ToListAsync();
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

        public async Task<Book> UpdateQuantityBook(Book book)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                Book book1 = await context.Books.FirstOrDefaultAsync(b => b.bookId == book.bookId);
                if (book1 == null) throw new Exception("Book not found");
                if(book1.bookId - book.bookId < 0)
                {
                    var errorResponse = new ErrorResponse
                    {
                        StatusCode = 404,
                        Message = "Số lượng trong kho không đủ. Vui lòng chọn lại số lượng!",
                        Details = "Lỗi khi đặt hàng số lượng"
                    };
                    throw new GraphQLException(errorResponse.Message);
                }
                else
                {
                    book1.quantity = book1.quantity - book.quantity;
                    await context.SaveChangesAsync();
                    return book1;
                }
            }
        }
    }
}
