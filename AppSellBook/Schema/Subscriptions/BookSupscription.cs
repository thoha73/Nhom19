using AppSellBook.Schema.Results;

namespace AppSellBook.Schema.Subscriptions
{
    public class BookSupscription
    {
        [Subscribe]
        public BookResult BookCreated([EventMessage] BookResult bookResult) => bookResult;
        [Subscribe]
        public CategoryResult CategoryCreated([EventMessage] CategoryResult categoryResult) => categoryResult;
    }
}
