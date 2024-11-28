using AppSellBook.Entities;

namespace AppSellBook.Services.OrderDetails
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
        Task<IEnumerable<Book>> GetBookNotCommentByUser(int userId);
    }
}
