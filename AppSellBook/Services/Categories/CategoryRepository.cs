using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace AppSellBook.Services.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContextFactory<BookDBContext> _dbContextFactory;
        public CategoryRepository(IDbContextFactory<BookDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            using(BookDBContext context=_dbContextFactory.CreateDbContext())
            {
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return category;
            }
        }

        public async Task<bool> DeleteCategory(int id)
        {
            using(BookDBContext context=_dbContextFactory.CreateDbContext())
            {
                Category category = new Category()
                {
                    categoryId = id
                };
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            using(BookDBContext context=_dbContextFactory.CreateDbContext())
            {
                return await context.Categories.Include(b=>b.books).ToListAsync();
            }
        }

        public async Task<Category> GetCategoryById(int id)
        {
            using(BookDBContext context= _dbContextFactory.CreateDbContext())
            {
                return await context.Categories.FirstOrDefaultAsync(c => c.categoryId == id);
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            using(BookDBContext context= _dbContextFactory.CreateDbContext())
            {
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                return category;
            }
        }
    }
}
