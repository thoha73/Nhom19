using AppSellBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppSellBook.Services.Images
{
    public class ImageRepository : IImageRepository
    {
        private readonly IDbContextFactory<BookDBContext> _contextFactory;

        public ImageRepository(IDbContextFactory<BookDBContext> contextFactory) {
            _contextFactory = contextFactory;
        }
        public async Task<Image> CreateImage(Image image)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Images.Add(image);
                await context.SaveChangesAsync();
                return image;
            }
        }

        public async Task<Image> UpdateImage(Image image)
        {
            using (BookDBContext context = _contextFactory.CreateDbContext())
            {
                context.Images.Update(image);
                await context.SaveChangesAsync();
                return image;
            }
        }
    }
}
