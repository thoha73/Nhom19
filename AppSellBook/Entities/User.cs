namespace AppSellBook.Entities
{
    public class User
    {
        public int userId {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string phone {  get; set; }
        public string email { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int point {  get; set; }
        public string purchaseAddress { get; set; }
        public string deliveryAddress { get; set; }
        public IEnumerable<Role> roles { get; set; }
        public IEnumerable<Cart> carts { get; set; }
        public IEnumerable<Order> orders { get; set; }
        public IEnumerable<CartDetail> cartDetails { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }
        public IEnumerable<Commentation> commentations { get; set; }
    }
}
