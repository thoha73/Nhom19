using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Notifications
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbContextFactory<BookDBContext> _dbContextFactory;
        public NotificationRepository(IDbContextFactory<BookDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<Notification> CreateNotification(Notification notification)
        {
            using(BookDBContext context=_dbContextFactory.CreateDbContext())
            {
                context.Notifications.Add(notification);
                await context.SaveChangesAsync();
                return notification;
            }
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsForUser(int userId)
        {
            using (BookDBContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Notifications.Where(n => n.userId == userId || n.userId == null) 
                      .OrderByDescending(n => n.createdAt)
                      .ToListAsync();
            }
            
        }
    }
}
