using AppSellBook.Schema.Types;

namespace AppSellBook.Schema.Results
{
    public class CommentationResult
    {
        public int commentationId { get; set; }
        public string content { get; set; }
        public double rank { get; set; }
        public int bookId { get; set; }
        public int userId { get; set; }
        public UserResult user { get; set; }
    }
}
