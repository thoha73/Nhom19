namespace AppSellBook.Entities
{
    public class BookCategory
    {
        public int booksbookId { get; set; }
        public Book book { get; set; }
        public int categoriescategoryId { get; set; }
        public Category category { get; set; }
    }
}
