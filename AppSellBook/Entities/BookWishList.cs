namespace AppSellBook.Entities
{
    public class BookWishList
    {
        public int booksbookId { get; set; }
        public Book book { get; set; }
        public int wishListswishListId { get; set; }
        public WishList wishList { get; set; }
    }
}
