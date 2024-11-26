namespace AppSellBookMVC.Models
{
    public class Book
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string description { get; set; }
        public string isbn { get; set; }
        public double listedPrice { get; set; }
        public double sellPrice { get; set; }
        public int quantity { get; set; }
        public Author author { get; set; }
        public double rank { get; set; }
        public List<Image> images { get; set; }
        public List<Category> categories { get; set; }
    }
}
