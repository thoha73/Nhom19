using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.OrderDetails
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public OrderDetailRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                context.OrderDetails.Add(orderDetail);
                await context.SaveChangesAsync();
                return orderDetail;
            }
        }

        public  async Task<IEnumerable<Book>> GetBookNotCommentByUser(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var dateExpired= DateTime.Now.AddDays(-25);
                var unreviewedBooks = await context.OrderDetails
                    .Where(cd => cd.order.userId == userId &&cd.order.orderStatus.Equals("Processing") && cd.order.orderDate>=dateExpired)
                    .Select(cd => cd.bookId) 
                    .Except(context.Commentations
                                .Where(c => c.userId == userId) 
                                .Select(c => c.bookId)) 
                    .Join(context.Books, bookId => bookId, book => book.bookId, (bookId, book) => book)
                    .ToListAsync();
                foreach (var book in unreviewedBooks)
                {
                    var images = await context.Images
                        .Where(i => i.bookId == book.bookId && i.icon == true)
                        .ToListAsync();
                    book.images = images;
                }

                return unreviewedBooks;
            }
        }
    }
}
