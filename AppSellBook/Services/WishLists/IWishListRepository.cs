using AppSellBook.Entities;

namespace AppSellBook.Services.WishLists
{
    public interface IWishListRepository
    {
        Task<WishList> GetWishListByUserId(int userId);
        Task<WishList> CreateWishList(WishList wishList);
        Task<IEnumerable<WishList>> GetAllWishListForUser(int userId);

    }
}
