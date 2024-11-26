using System.Diagnostics.CodeAnalysis;

namespace AppSellBook.Schema.Inputs
{
    public class RegisterInfor
    {
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string purchaseAddress { get; set; }
        public string deliveryAddress { get; set; }
    }
}
