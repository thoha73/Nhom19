namespace AppSellBook.Schema.Types
{
    public class ImageType
    {
        public int imageId {  get; set; }   
        public string imageName { get; set; }
        public string? imageData { get; set; }
        public bool icon { get; set; }
        public int bookId {  get; set; }
    }
}
