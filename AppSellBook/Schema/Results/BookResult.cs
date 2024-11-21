namespace AppSellBook.Schema.Results
{
    public class BookResult
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string ISBN { get; set; }
        public double listedPrice { get; set; }
        public double sellPrice { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public double rank { get; set; }
        public IEnumerable<ImageResult> images { get; set; }
        public string message { get; set; }
    }
}
