namespace AppSellBook.Entities
{
    public class Cart
    {
        public int cartId { get; set; }
        public DateTime createDate { get; set; }
        public string purchaseAddress { get; set; }
        public string deliveryAddress { get; set; } 
        public IEnumerable<CartDetail> cartDetails { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
    }
}
