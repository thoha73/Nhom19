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

        public async Task<IEnumerable<OrderDetail>> GetBookNotCommentByUser(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                var dateExpired = DateTime.Now.AddDays(-5);
                var orderDetails = await context.OrderDetails
                    .Where(cd => cd.order.userId == userId
                                 && cd.order.orderStatus.Equals("Processing")
                                 && cd.order.orderDate >= dateExpired)
                    .ToListAsync();

                var reviewedBookIds = await context.Commentations
                    .Where(c => c.userId == userId)
                    .Select(c => c.bookId)
                    .ToListAsync();

                // Lọc ra những OrderDetail chưa có sách nào đã được đánh giá
                var unreviewedOrderDetails = orderDetails
                    .Where(cd => !reviewedBookIds.Contains(cd.bookId))
                    .ToList();

                // Lấy thông tin sách tương ứng với OrderDetail chưa có comment
                foreach (var orderDetail in unreviewedOrderDetails)
                {
                    var book = await context.Books
                        .Where(b => b.bookId == orderDetail.bookId)
                        .FirstOrDefaultAsync();

                    if (book != null)
                    {
                        // Lấy các hình ảnh có icon cho sách
                        var images = await context.Images
                            .Where(i => i.bookId == book.bookId && i.icon)
                            .ToListAsync();

                        book.images = images;
                        orderDetail.book = book; // Gắn thông tin sách vào OrderDetail
                    }
                }

                return unreviewedOrderDetails;
            }
        }

    }
}
