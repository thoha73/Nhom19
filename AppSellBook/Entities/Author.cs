namespace AppSellBook.Entities
{
    public class Author
    {
        public int authorId { get; set; }
        public string authorName { get; set; }
        public string gender { get; set; } 
        public DateTime dateOfBirth { get; set; }
        public List<Book> books { get; set; }
    }
}
