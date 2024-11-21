namespace AppSellBook.Entities
{
    public class Commentation
    {
        public int commentationId { get; set; }
        public string content { get; set; }
        public double ranK { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
