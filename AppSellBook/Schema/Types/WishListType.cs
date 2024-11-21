namespace AppSellBook.Schema.Types
{
    public class WishListType
    {
        public int wishListId { get; set; } 
        public string wishListName { get; set; }
        public IEnumerable<BookType> books { get; set; }
        public int userId { get; set; }
        public UserType user { get; set; }
    }
}
