using AppSellBook.Entities;

namespace AppSellBook.Services.Commentations
{
    public interface ICommentationRepository
    {
        Task<IEnumerable<Commentation>> GetCommentationsByBookIdAsync(int bookId);
        Task<Commentation> CreateCommentation(Commentation commentation);
        Task<bool> DeleteCommentation(int commentationId);
    }
}
