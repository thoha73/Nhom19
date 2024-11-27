namespace AppSellBook.Schema.Results
{
    public class UserResult
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public int point { get; set; }
        public string purchaseAddress { get; set; }
        public string deliveryAddress { get; set; }
        public List<RoleUserResult> roleUsers { get; set; }
    }
}
