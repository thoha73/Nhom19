namespace AppSellBook.Entities
{
    public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public IEnumerable<Book> books { get; set; }

    }
}
