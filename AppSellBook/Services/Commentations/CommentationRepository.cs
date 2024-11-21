using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Commentations
{
    public class CommentationRepository : ICommentationRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;
        public CommentationRepository(IDbContextFactory<BookDBContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Commentation> CreateCommentation(Commentation commentation)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                context.Commentations.AddAsync(commentation);
                await context.SaveChangesAsync();
                return commentation;
            }
        }

        public async Task<bool> DeleteCommentation(int commentationId)
        {
            using (BookDBContext context =_contextFactory.CreateDbContext())
            {
                Commentation comment = new Commentation()
                {
                    commentationId = commentationId
                };
                context.Commentations.Remove(comment);
                return await context.SaveChangesAsync()>0;
            }
        }

        public async Task<IEnumerable<Commentation>> GetCommentationsByBookIdAsync(int bookId)
        {
            using(BookDBContext context= _contextFactory.CreateDbContext())
            {
                return await context.Commentations.Include(u=>u.user).Where(r=>r.bookId==bookId).ToListAsync();
            }
        }
    }
}
