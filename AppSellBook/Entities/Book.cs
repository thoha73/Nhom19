namespace AppSellBook.Entities
{
    public class Book
    {
        public int bookId { get; set; }
        public string bookName { get; set; }   
        public string ISBN { get; set; }
        public double listedPrice {get; set; }
        public double sellPrice { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string? publisher { get; set; }  
        public int authorId { get; set; }
        public Author author { get; set; }
        public double rank { get; set; }
        public IEnumerable<BookCategory> bookCategories { get; set; }
        public IEnumerable<Image> images { get; set; }
        public IEnumerable<CartDetail> cartDetails { get; set; }
        public IEnumerable<OrderDetail> orderDetails { get; set; }
        public IEnumerable<BookWishList> bookWishLists { get; set; }
        public IEnumerable<Commentation> commentations { get; set; }

    }
}
