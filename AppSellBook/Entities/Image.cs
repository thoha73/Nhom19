using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AppSellBook.Entities
{
    public class Image
    {
        public int imageId { get; set; }
        public string imageName { get; set; }
        [AllowNull]
        public byte[] imageData { get; set; }
        public bool icon { get; set; }
        public int bookId { get; set; }
        [AllowNull]
        public Book book { get; set; }
    }
}
