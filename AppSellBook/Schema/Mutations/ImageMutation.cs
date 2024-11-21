using AppSellBook.Schema.Results;
using AppSellBook.Schema.Types;
using AppSellBook.Services.Images;
using AppSellBook.Entities;

namespace AppSellBook.Schema.Mutations
{
    public class ImageMutation
    {
        private readonly IImageRepository _imageRepository;
        public ImageMutation(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        public async Task<ImageResult> CreateImage(Image image)
        {

            image = await _imageRepository.CreateImage(image);
            ImageResult imageResult = new ImageResult()
            {
                imageName= image.imageName,
                imageData= Convert.ToBase64String(image.imageData),
                icon= image.icon,
            };
            return imageResult; 
        }
    }
}
