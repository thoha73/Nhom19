﻿
using AppSellBook.Schema.Types;
using AppSellBook.Services.Books;
using AppSellBook.Entities;
using AppSellBook.Services.Categories;
using AppSellBook.Services.Commentations;
using AppSellBook.Schema.Results;
using AppSellBook.Services.CartDetails;
using AppSellBook.Services.WishLists;
using AppSellBook.Services.Users;
<<<<<<< HEAD
using AppSellBook.Services.OrderDetails;
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300

namespace AppSellBook.Schema.Queries
{
    public class BookQuery
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICommentationRepository _commentationRepository;
        private readonly ICartDetailRepository _cartDetailRepository;
        private readonly IWishListRepository _wishListRepository;
        private readonly IUserRepository _userRepository;
<<<<<<< HEAD
        private readonly IOrderDetailRepository _orderDetailRepository;
        public BookQuery(IBookRepository bookRepository, ICategoryRepository categoryRepository, ICommentationRepository commentationRepository, ICartDetailRepository cartDetailRepository,IWishListRepository wishListRepository,IUserRepository userRepository,IOrderDetailRepository orderDetailRepository)
=======
        public BookQuery(IBookRepository bookRepository, ICategoryRepository categoryRepository, ICommentationRepository commentationRepository, ICartDetailRepository cartDetailRepository,IWishListRepository wishListRepository,IUserRepository userRepository)
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _commentationRepository = commentationRepository;
            _cartDetailRepository = cartDetailRepository;
            _wishListRepository = wishListRepository;
            _userRepository = userRepository;
<<<<<<< HEAD
            _orderDetailRepository = orderDetailRepository;
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
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
                publisher=b.publisher,
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
                publisher = b.publisher,
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
                publisher = bookDTO.publisher,
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
                cartDetailId = b.cartDetailId,
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
<<<<<<< HEAD
        public async Task<IEnumerable<BookResult>> GetBookNotComment(int userId)
        {
            IEnumerable<Book> books=await _orderDetailRepository.GetBookNotCommentByUser(userId);
            return books.Select(b => new BookResult()
            {
                bookId = b.bookId,
                bookName = b.bookName,
                images = b.images
                .Where(i => i.icon == true)
                .Select(i => new ImageResult()
                {
                    imageName = i.imageName,
                    imageData = Convert.ToBase64String(i.imageData),
                }).ToList(),
            }).ToList();
        }
        public async Task<int> GetBookCountInCart(int userId)
        {
            return await _cartDetailRepository.GetBookCountInCart(userId);
        }
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
        //WishLists
        public async Task<IEnumerable<BookResult>> GetWishListForUser(int userId)
        {
            IEnumerable<WishList> wishLists = await _wishListRepository.GetAllWishListForUser(userId);

            // Chuyển đổi danh sách sách yêu thích thành BookResult
            var bookResults = wishLists
            .SelectMany(w => w.bookWishLists)  // Dùng SelectMany để lấy tất cả các sách trong danh sách yêu thích
            .Select(bw => new BookResult()
            {
                bookId = bw.book.bookId,  // Lấy bookId từ book trong BookWishList
                bookName = bw.book.bookName,
                images = bw.book.images != null  // Kiểm tra xem images có null không
                ? bw.book.images
                    .Where(i => i.icon == true)
                    .Select(i => new ImageResult()
                    {
                        imageName = i.imageName,
                        imageData = Convert.ToBase64String(i.imageData),
                        icon = i.icon
                    }).ToList()
                : new List<ImageResult>(),
                author = bw.book.author != null  
                ? new AuthorResult()
                {
                    authorId = bw.book.author.authorId,
                    authorName = bw.book.author.authorName
                }
                : null,
                description = bw.book.description,
                rank = bw.book.rank,
                listedPrice = bw.book.listedPrice,
                sellPrice = bw.book.sellPrice
            }).ToList();
            return bookResults;
        }
        //User
        public async Task<UserResult> GetUserById(int userId)
        {
            User userDTO= await _userRepository.GetUserById(userId);
            return new UserResult()
            {
                firstName = userDTO.firstName,
                lastName = userDTO.lastName,
                email = userDTO.email,
                gender = userDTO.gender,
                phone = userDTO.phone,
                purchaseAddress = userDTO.purchaseAddress,
                deliveryAddress = userDTO.deliveryAddress,
                point = userDTO.point,
            };
        }
    }
}
