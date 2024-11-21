namespace AppSellBook.Schema.Types
{ 
    public class RoleType
    {
        public int roleId { get; set; }
        public string roleName { get; set; }  
        public IEnumerable<UserType> users { get; set; }
    }
}
