using AppSellBook.Entities;
using AppSellBook.Schema.Types;
using AppSellBook.Services.Categories;

namespace AppSellBook.Schema.Queries
{
    [ExtendObjectType("Query")]
    public class CategoryQuery
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryType>> GetCategories()
        {
            IEnumerable<Category> categoryDTOs= await _categoryRepository.GetAllCategories();
            return categoryDTOs.Select(c => new CategoryType()
            {
                categoryId=c.categoryId,
                categoryName=c.categoryName,

            });
        }
    }
}
