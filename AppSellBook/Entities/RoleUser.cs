namespace AppSellBook.Entities
{
    public class RoleUser
    {
        public int usersuserId { get; set; }
        public User User { get; set; }

        public int rolesroleId { get; set; }
        public Role Role { get; set; }
    }
}
