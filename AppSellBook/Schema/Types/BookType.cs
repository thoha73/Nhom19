
using GraphQL;

namespace AppSellBook.Schema.Types
{
    public class BookType
    {
        public int bookId { get; set; } 
        public string bookName { get; set; }
        public string ISBN { get; set; }
        public double listedPrice { get; set; }
        public double sellPrice { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public AuthorType author { get; set; }
        public double? rank { get; set; }
        public IEnumerable<ImageType> images { get; set; }
        public IEnumerable<CategoryType> categories { get; set; }

    }
}
