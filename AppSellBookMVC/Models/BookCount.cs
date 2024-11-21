namespace AppSellBookMVC.Models
{
    public class BookCount
    {
        public int bookCount { get; set; }
        public List<Book> books { get; set; }
        public BookCreated bookCreated { get; set; }
        public Book bookById {  get; set; }
        public List<Category> categories { get; set; }
    }
}
