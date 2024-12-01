using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public OrderRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
                return order;
            }
            
        }


        public async Task<bool> DeleteOrder(Order order)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Orders.Remove(order);
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<Entities.Order> GetOrderById(int orderId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                
                return await context.Orders.FirstOrDefaultAsync(r=>r.orderId==orderId);
            }
        }
    }
}
