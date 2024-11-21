namespace AppSellBook.Schema.Types
{
    public class UserType
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
        public IEnumerable<RoleType> roles { get; set; }
        public IEnumerable<CartType> carts { get; set; }
        public IEnumerable<OrderType> orders { get; set; }
        public IEnumerable<CartDetailType> cartDetails { get; set; }
        public IEnumerable<WishListType> wishLists { get; set; }
        public IEnumerable<CommentationType> commentations { get; set; }
    }
}
