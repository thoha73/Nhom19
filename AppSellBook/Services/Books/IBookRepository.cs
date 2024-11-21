using AppSellBook.Entities;

namespace AppSellBook.Services.Books
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int bookId);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<bool> DeleteBook(int bookId);
        Task<bool> DeleteBooksAsync(List<int> bookIds);
        Task<int> GetBookCount();
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId);
    }
}
