using System.ComponentModel.DataAnnotations;

namespace AppSellBook.Entities
{
    public class CartDetail
    {
        [Key]
        public int cartDetailId { get; set; }
        public Book book { get; set; }
        public Cart cart { get; set; }
        public int cartId { get; set; }
        public int bookId { get; set; }
        public int quantity { get; set; }   
        public double sellPrice { get; set; } 
        public bool isSelected { get; set; }
    }
}
