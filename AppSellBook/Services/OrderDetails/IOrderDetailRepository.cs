using AppSellBook.Entities;

namespace AppSellBook.Services.OrderDetails
{
    public interface IOrderDetailRepository
    {
        Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetBookNotCommentByUser(int userId);
    }
}
