using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public AuthorRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<Author>> GetAuthor()
        {
           using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Authors.ToListAsync();
            }
        }
    }
}
