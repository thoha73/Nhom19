
namespace AppSellBook.Schema.Types
{
    public class CartDetailType
    {
        public int cardDetailId { get; set; }
        public BookType book { get; set; }
        public CartType cart { get; set; }
        public int cardId { get; set; }
        public int bookId { get; set; }
        public int quantity { get; set; }   
        public double sellPrice { get; set; }   
    }
}
