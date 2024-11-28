namespace AppSellBook.Entities
{
    public class WishList
    {
        public int wishListId { get; set; } 
        public string wishListName { get; set; }
        public IEnumerable<BookWishList> bookWishLists { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
