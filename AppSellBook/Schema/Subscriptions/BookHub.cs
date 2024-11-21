using Microsoft.AspNetCore.SignalR;

namespace AppSellBook.Schema.Subscriptions
{
    public class BookHub: Hub
    {
        public async Task sendMessage(string mess, string bookName, string isbn, double sellPrice, string description)
        {
            await Clients.All.SendAsync("ReceiveMessage", mess, bookName, isbn, sellPrice, description);
        }
    }
}
