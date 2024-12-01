namespace AppSellBook.Schema.Results
{
    public class OrderDetailResult
    {
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int bookId { get; set; }
        public BookResult book { get; set; }
        public OrderResult order { get; set; }
        public int quantity { get; set; }
        public double sellPrice { get; set; }
    }
}
