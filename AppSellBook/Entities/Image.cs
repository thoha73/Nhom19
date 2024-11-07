namespace AppSellBook.Entities
{
    public class Image
    {
        public int imageId { get; set; }
        public string imageName { get; set; }
        public byte[] imageData { get; set; }
        public bool icon { get; set; }
        public int bookId {  get; set; }
        public Book book { get; set; }
    }
}
