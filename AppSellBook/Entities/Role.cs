using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppSellBook.Entities
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }  
        public IEnumerable<RoleUser> roleUsers { get; set; }
    }
}
