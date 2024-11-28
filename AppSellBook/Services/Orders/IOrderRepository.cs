using AppSellBook.Entities;

namespace AppSellBook.Services.Orders
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
    }
}
