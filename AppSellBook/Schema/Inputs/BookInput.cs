using AppSellBook.Schema.Types;

namespace AppSellBook.Schema.Inputs
{
    public class BookInput
    {
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string ISBN { get; set; }
        public double listedPrice { get; set; }
        public double sellPrice { get; set; }
        public int quantity { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public double rank { get; set; }
        public IEnumerable<ImageType> images { get; set; }

    }
}
