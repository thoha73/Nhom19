using AppSellBook.Entities;

namespace AppSellBook.Services.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(int id);

    }
}
