using AppSellBook.Entities;

namespace AppSellBook.Services.Images
{
    public interface IImageRepository
    {
        Task<Image> CreateImage(Image book);
        Task<Image> UpdateImage(Image image);
    }
}
