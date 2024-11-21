namespace AppSellBook.Schema.Types
{
    public class OrderDetailType
    {
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int booId { get; set; }
        public BookType book { get; set; }
        public OrderType order { get; set; } 
        public int quantity { get; set; }
        public double sellPrice { get; set; }   
    }
}
