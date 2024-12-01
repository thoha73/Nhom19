using AppSellBook.Entities;

namespace AppSellBook.Schema.Results
{
    public class CartDetailResult
    {
        public int cartDetailId { get; set; }
        public BookResult book { get; set; }
        public Cart cart { get; set; }
        public int cartId { get; set; }
        public int bookId { get; set; }
        public int quantity { get; set; }
        public double sellPrice { get; set; }
        public bool isSelected { get; set; }    
    }
}
