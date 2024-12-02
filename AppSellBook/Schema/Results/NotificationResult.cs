namespace AppSellBook.Schema.Results
{
    public class NotificationResult
    {
        public string context { get; set; }
        public DateTime createdAt { get; set; }
        public bool isRead { get; set; }
        public int? userId { get; set; }
        public UserResult user { get; set; }
    }
}
