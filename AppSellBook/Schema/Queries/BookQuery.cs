
using AppSellBook.Schema.Types;
using AppSellBook.Services.Books;
using AppSellBook.Entities;
using AppSellBook.Services.Categories;
using AppSellBook.Services.Commentations;
using AppSellBook.Schema.Results;
using AppSellBook.Services.CartDetails;

namespace AppSellBook.Schema.Queries
{
    public class BookQuery
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentationRepository _commentationRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        public BookQuery(IBookRepository bookRepository, ICategoryRepository categoryRepository, ICommentationRepository commentationRepository, ICartDetailRepository cartDetailRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _commentationRepository = commentationRepository;
            _cartDetailRepository = cartDetailRepository;
        }
        //Books
        [UseSorting]
        public async Task<IEnumerable<BookType>> GetBooks()
        {
           IEnumerable<Book> bookDTO= await _bookRepository.GetAllBooks();
            return bookDTO.Select(b => new BookType()
            {
                bookId=b.bookId,
                bookName = b.bookName,
                ISBN = b.ISBN,
                listedPrice = b.listedPrice,
                sellPrice = b.sellPrice,
                quantity = b.quantity,
                description = b.description,
                author=b.author!=null?new AuthorType()
                {
                    authorId=b.author.authorId,
                    authorName=b.author.authorName
                }: new AuthorType()
                {
                    authorId=-1,
                    authorName="Unknown"
                },
                rank = b.rank,
                images = b.images.Select(i => new ImageType
                {
                    imageId = i.imageId,
                    imageName = i.imageName,
                    imageData = Convert.ToBase64String(i.imageData),
                    icon = i.icon,
                }).ToList(),
                categories = b.categories.Select(c => new CategoryType()
                {
                    categoryId = c.categoryId,
                    categoryName = c.categoryName,
                })


            }); ;
        }
        public async Task<IEnumerable<BookType>> GetBooksByCategory(int categoryId)
        {
            IEnumerable<Book> bookDTO = await _bookRepository.GetBooksByCategory(categoryId);
            return bookDTO.Select(b => new BookType()
            {
                bookId = b.bookId,
                bookName = b.bookName,
                ISBN = b.ISBN,
                listedPrice = b.listedPrice,
                sellPrice = b.sellPrice,
                quantity = b.quantity,
                description = b.description,
                author = b.author != null ? new AuthorType()
                {
                    authorId = b.author.authorId,
                    authorName = b.author.authorName
                } : new AuthorType()
                {
                    authorId = -1,
                    authorName = "Unknown"
                },
                rank = b.rank,
                images = b.images.Select(i => new ImageType
                {
                    imageId = i.imageId,
                    imageName = i.imageName,
                    imageData = Convert.ToBase64String(i.imageData),
                    icon = i.icon,
                }).ToList(),
                categories = b.categories.Select(c => new CategoryType()
                {
                    categoryId = c.categoryId,
                    categoryName = c.categoryName,
                })



            }); ;
        }
        public async Task<BookType> GetBookByIdAsync(int id) {
            Book bookDTO= await _bookRepository.GetBookById(id);
            return new BookType()
            {
                bookId=bookDTO.bookId,
                bookName = bookDTO.bookName,
                ISBN = bookDTO.ISBN,
                listedPrice = bookDTO.listedPrice,
                sellPrice = bookDTO.sellPrice,
                quantity = bookDTO.quantity,
                description = bookDTO.description,
                author = bookDTO.author != null ? new AuthorType()
                {
                    authorId = bookDTO.author.authorId,
                    authorName = bookDTO.author.authorName
                } : new AuthorType()
                {
                    authorId = -1,
                    authorName = "Unknown"
                },
                rank = bookDTO.rank,
                images = bookDTO.images.Select(i => new ImageType
                {
                    imageId = i.imageId,
                    imageName = i.imageName,
                    imageData = Convert.ToBase64String(i.imageData),
                    icon = i.icon,
                }).ToList(),
                categories = bookDTO.categories.Select(c => new CategoryType()
                {
                    categoryId = c.categoryId,
                    categoryName = c.categoryName,
                })

            };
        }
        public async Task<int> GetBookCount()
        {
            return await _bookRepository.GetBookCount();
        }
        //Categories
        public async Task<IEnumerable<CategoryType>> GetCategories()
        {
            IEnumerable<Category> categoryDTOs = await _categoryRepository.GetAllCategories();
            return categoryDTOs.Select(c => new CategoryType()
            {
                categoryId = c.categoryId,
                categoryName = c.categoryName,

            });
        }
        //Commentations
        public async Task<IEnumerable<CommentationResult>> GetCommentationsByBookId(int bookId)
        {
            IEnumerable<Commentation> commentDTO= await _commentationRepository.GetCommentationsByBookIdAsync(bookId);
            return commentDTO.Select(c => new CommentationResult()
            {
                commentationId = c.commentationId,
                content = c.content,
                rank = c.ranK,
                user = new UserResult
                {
                    userId = c.user.userId,
                    lastName = c.user.lastName,
                    firstName = c.user.firstName,

                }
            }); 
            
        }
        //CartDetails
        public async Task<IEnumerable<CartDetailResult>> GetCartDetail(int userId)
        {
            IEnumerable<CartDetail> cartDetailDTO= await _cartDetailRepository.GetBooksInCart(userId);
            return cartDetailDTO.Select(b => new CartDetailResult()
            {
                cartDetailId = b.cardDetailId,
                quantity = b.quantity,
                sellPrice = b.sellPrice,
                book = new BookResult()
                {
                    bookId = b.bookId,
                    bookName=b.book.bookName,
                    images =(IEnumerable<ImageResult>) b.book.images.Where(i=>i.icon == true).Select(i => new ImageResult()
                    {
                        imageName = i.imageName,
                        imageData = Convert.ToBase64String(i.imageData),
                        icon = i.icon
                    }).ToList(),

                }
            }).ToList() ;
        }
    }
}
