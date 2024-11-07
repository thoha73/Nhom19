using System.ComponentModel.DataAnnotations;

namespace AppSellBook.Entities
{
    public class CartDetail
    {
        [Key]
        public int cardDetailId { get; set; }
        public Book book { get; set; }
        public Cart cart { get; set; }
        public int cardId { get; set; }
        public int bookId { get; set; }
        public int quantity { get; set; }   
        public double sellPrice { get; set; }   
    }
}
