using AppSellBook.Entities;

namespace AppSellBook.Services.WishLists
{
    public interface IBookWishListRepository
    {
        Task<BookWishList> CreateBookWishList(BookWishList bookWishList);
        Task<bool> existsInBookWishList(int wishListId, int bookId);
    }
}
