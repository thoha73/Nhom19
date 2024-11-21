namespace AppSellBook.Schema.Types
{
    public class CartType
    {
        public int cartId { get; set; }
        public DateTime createDate { get; set; }
        public string purchaseAddress { get; set; }
        public string deliveryAddress { get; set; } 
        public IEnumerable<CartDetailType> cartDetails { get; set; }
        public int userId { get; set; }
        public UserType user { get; set; }
    }
}
