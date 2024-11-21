using Microsoft.AspNetCore.SignalR;

namespace AppSellBookMVC.Models
{
    public class BookHub: Hub
    {
        public async Task sendMessage(string mess, string bookName, string isbn, double sellPrice, string description)
        {
            await Clients.All.SendAsync("ReceiveMessage", mess, bookName, isbn, sellPrice, description);
        }
    }
}
