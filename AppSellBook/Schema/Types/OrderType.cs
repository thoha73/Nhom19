namespace AppSellBook.Schema.Types
{
    public enum StatusOrder
    {
        New=0,
        Payment=1,
        Complete=2,
        Cancel=-1
    }
    public class OrderType
    {
        public int orderId {  get; set; } 
        public DateTime orderDate { get; set; }
        public string purchaseAddress { get; set; } 
        public string deliveryAddress { get; set; }
        public string orderStatus { get; set; }
        public DateTime? deliveryDate { get; set; }
        public StatusOrder paymentMethod { get; set; }
        public IEnumerable<OrderDetailType> orderDetails { get; set;}
        public int userId { get; set; }
        public UserType user { get; set; }
    }
}
