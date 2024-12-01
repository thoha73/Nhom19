namespace AppSellBook.Entities
{
    public class Notification
    {
        public int notificationId { get; set; }
        public int? userId { get; set; }
        public string context { get; set; }
        public bool isRead { get; set; }
        public DateTime createdAt {  get; set; }
        public User? user { get; set; }
    }
}
