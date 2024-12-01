using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.CartDetails
{
    public class CartDetailRepository : ICartDetailRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public CartDetailRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<CartDetail> CreateCartDetail(CartDetail cartDetail)
        {
            using(BookDBContext context=_contextFactory.CreateDbContext())
            {
                context.CartDetails.Add(cartDetail);
                await context.SaveChangesAsync();
                return cartDetail;
            }
        }

        public async Task<bool> deleteCartDetail(int cartDetailId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                CartDetail cartDetail = new CartDetail()
                {
                    cartDetailId = cartDetailId
                };
                context.CartDetails.Remove(cartDetail);
                
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<bool> existsInCart(int cartId, int bookId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {

                return await context.CartDetails.AnyAsync(r => r.cartId == cartId && r.bookId == bookId);
            }
        }
        public async Task<int> GetBookCountInCart(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {

                return await context.CartDetails.Where(c=>c.cart.userId==userId).CountAsync();
            }
        }

        public async Task<IEnumerable<CartDetail>> GetBooksInCart(int userId)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
               return await context.CartDetails.Include(b=>b.book)
                                                .ThenInclude(i=>i.images)
                                                .Where(c=>c.cart.userId==userId)
                                                .AsNoTracking().ToListAsync();
            }
        }

        public async Task<bool> updateCheckBox(CartDetail cartDetail)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var existingCartDetail = await context.CartDetails
                                                         .FirstOrDefaultAsync(cd => cd.cartDetailId == cartDetail.cartDetailId);
                    if (existingCartDetail == null)
                    {
                        Console.WriteLine("CartDetail not found");
                        return false;
                    }
                    existingCartDetail.isSelected = cartDetail.isSelected;
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating checkbox: {ex.Message}");
                    return false;
                }
            }
        }

        public async Task<bool> updateQuantity(int cartDetailId, int quantity)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                try
                {
                    var existingCartDetail = await context.CartDetails
                                                         .FirstOrDefaultAsync(cd => cd.cartDetailId == cartDetailId);
                    if (existingCartDetail == null)
                    {
                        Console.WriteLine("CartDetail not found");
                        return false;
                    }


                    existingCartDetail.quantity = quantity;
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating checkbox: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
