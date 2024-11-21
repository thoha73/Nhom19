namespace AppSellBook.Entities
{
    public class OrderDetail
    {
        public int orderDetailId { get; set; }
        public int orderId { get; set; }
        public int bookId { get; set; }
        public Book book { get; set; }
        public Order order { get; set; } 
        public int quantity { get; set; }
        public double sellPrice { get; set; }   
    }
}
