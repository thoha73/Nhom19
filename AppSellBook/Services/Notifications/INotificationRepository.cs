using AppSellBook.Entities;

namespace AppSellBook.Services.Notifications
{
    public interface INotificationRepository
    {
        Task<Notification> CreateNotification(Notification notification);
        Task<IEnumerable<Notification>> GetAllNotificationsForUser(int userId);
        Task<IEnumerable<Notification>> GetAllNotificationsForShop(int userId);
        Task<bool> UpdateRead(Notification notification);
    }
}
