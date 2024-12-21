using AppSellBook.Entities;

namespace AppSellBook.Schema.Results
{
    public class OrderResult
    {
        public int orderId { get; set; }
        public string deliveryAddress { get; set; }
        public string orderStatus { get; set; }
        public DateTime? deliveryDate { get; set; }
        public int paymentMethod { get; set; }
        public IEnumerable<OrderDetailResult> orderDetails { get; set; }
        public UserResult user { get; set; }
        public double totalMoney { get; set; }
    }
}
