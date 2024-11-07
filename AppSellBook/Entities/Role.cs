namespace AppSellBook.Entities
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }  
        public IEnumerable<User> users { get; set; }
    }
}
