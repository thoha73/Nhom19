using AppSellBook.Entities;
using AppSellBook.Schema.Inputs;
using AppSellBook.Schema.Results;
using AppSellBook.Schema.Subscriptions;
using AppSellBook.Schema.Types;
using AppSellBook.Services.Books;
using AppSellBook.Services.CartDetails;
using AppSellBook.Services.Categories;
using AppSellBook.Services.Commentations;
using AppSellBook.Services.Images;
using AppSellBook.Services.OrderDetails;
using AppSellBook.Services.Orders;
using AppSellBook.Services.PasswordHashers;
using AppSellBook.Services.Roles;
using AppSellBook.Services.Users;
using AppSellBook.Services.WishLists;
using HotChocolate.Subscriptions;
using System.Collections.Generic;
using System.Linq;

public class BookMutation
{
    private readonly IBookRepository _bookRepository;
    private readonly IImageRepository _imageRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICommentationRepository _commentationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHashser _passwordHashser;
    private readonly IRoleRepository _roleRepository;
    private readonly IRoleUserRepository _roleUserRepository;
    private readonly IWishListRepository _wishListRepository;
    private readonly IBookWishListRepository _bookWishListRepository;
    private readonly ICartRepository _cartRepository;
    private readonly ICartDetailRepository _cartDetailRepository;
<<<<<<< HEAD
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderDetailRepository _orderDetailRepository;
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    public BookMutation(IBookRepository bookRepository, IImageRepository imageRepository,
                        ICategoryRepository categoryRepository,ICommentationRepository commentationRepository,
                        IUserRepository userRepository ,IPasswordHashser passwordHashser,IRoleRepository roleRepository,
                        IRoleUserRepository roleUserRepository, IWishListRepository wishListRepository, IBookWishListRepository bookWishListRepository,
<<<<<<< HEAD
                        ICartRepository cartRepository,ICartDetailRepository cartDetailRepository,IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
=======
                        ICartRepository cartRepository,ICartDetailRepository cartDetailRepository)
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    {
        _bookRepository = bookRepository;
        _imageRepository = imageRepository;
        _categoryRepository = categoryRepository;
        _commentationRepository = commentationRepository;
        _userRepository = userRepository;
        _passwordHashser = passwordHashser;
        _roleRepository=roleRepository;
        _roleUserRepository = roleUserRepository;
        _wishListRepository = wishListRepository;
        _bookWishListRepository = bookWishListRepository;
        _cartRepository = cartRepository;
        _cartDetailRepository = cartDetailRepository;
<<<<<<< HEAD
        _orderRepository = orderRepository;
        _orderDetailRepository= orderDetailRepository;
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    }
    //Book
    public async Task<BookResult> CreateBook(BookInput bookTypeInput,int authorId, [Service] ITopicEventSender topicEventSender)
    {
        Book book = new Book()
        {
            bookName = bookTypeInput.bookName,
            ISBN = bookTypeInput.ISBN,
            listedPrice = bookTypeInput.listedPrice,
            sellPrice = bookTypeInput.sellPrice,
            quantity = bookTypeInput.quantity,
            description = bookTypeInput.description,
            rank = bookTypeInput.rank,
            authorId = authorId,
            

            // List<int> ids,
            //categories = categoryId.Select(id => new Category { categoryId = id }).ToList()
        };
        book = await _bookRepository.CreateBook(book);

        if (bookTypeInput.images != null && bookTypeInput.images.Any())
        {
            foreach (var imageType in bookTypeInput.images)
            {
                byte[] imagebytes = Convert.FromBase64String(imageType.imageData);
                Image image = new Image()
                {
                    imageName = imageType.imageName,
                    imageData = imagebytes,
                    icon = imageType.icon,
                    bookId = book.bookId,
                };

                await _imageRepository.CreateImage(image);
            }
        }

        BookResult bookResult = new BookResult()
        {
            bookId = book.bookId,
            bookName = book.bookName,
            ISBN = book.ISBN,
            listedPrice = book.listedPrice,
            sellPrice = book.sellPrice,
            quantity = book.quantity,
            description = book.description,
            //author = book.author,
            images = bookTypeInput.images?.Select(i => new ImageResult
            {
                imageName = i.imageName,
                imageData = i.imageData,
                icon = i.icon
            }),
            message = "Sản phẩm mới vừa ra mắt"
        };
        await topicEventSender.SendAsync(nameof(BookSupscription.BookCreated),bookResult);
        return bookResult;
    }
    public async Task<BookResult> UpdateBook(int id, BookType bookTypeInput)
    {
        Book bookDTO = new Book()
        {
            bookId = id,
            bookName= bookTypeInput.bookName,
            ISBN = bookTypeInput.ISBN,
            listedPrice = bookTypeInput.listedPrice,
            sellPrice = bookTypeInput.sellPrice,
            quantity = bookTypeInput.quantity,
            description = bookTypeInput.description,
            //author = bookTypeInput.author,
        };
        bookDTO = await _bookRepository.UpdateBook(bookDTO);
        if (bookTypeInput.images != null && bookTypeInput.images.Any())
        {
            foreach (var imageType in bookTypeInput.images)
            {
                byte[] imagebytes = Convert.FromBase64String(imageType.imageData);
                Image image = new Image()
                {
                    imageId=imageType.imageId,
                    imageName = imageType.imageName,
                    imageData = imagebytes,
                    icon = imageType.icon,
                    bookId = bookDTO.bookId,
                };

                await _imageRepository.UpdateImage(image);
            }
        }
        BookResult bookResult = new BookResult()
        {
            bookId = bookDTO.bookId,
            bookName = bookDTO.bookName,
            ISBN = bookDTO.ISBN,
            listedPrice = bookDTO.listedPrice,
            sellPrice = bookDTO.sellPrice,
            quantity = bookDTO.quantity,
            description = bookDTO.description,
            //author = bookDTO.author,
            images = bookTypeInput.images?.Select(i => new ImageResult
            {
                imageName = i.imageName,
                imageData = i.imageData,
                icon = i.icon
            }),
        };
        return bookResult;
    }
    //Category
    public async Task<CategoryResult> CreateCategory(CategoryType categoryType, [Service] ITopicEventSender topicEventSender)
    {
        Category categoryDTO = new Category()
        {
            categoryName = categoryType.categoryName,
        };
        categoryDTO = await _categoryRepository.CreateCategory(categoryDTO);
        CategoryResult categoryResult = new CategoryResult()
        {
            categoryId = categoryDTO.categoryId,
            categoryName = categoryDTO.categoryName,
        };
       await topicEventSender.SendAsync(nameof(BookSupscription.CategoryCreated), categoryResult);
        return categoryResult;
    }
    public async Task<CategoryResult> UpdateCategory(int id, CategoryType category)
    {
        Category categoryDTO = new Category()
        {
            categoryId = id,
            categoryName = category.categoryName,
        };
        categoryDTO = await _categoryRepository.UpdateCategory(categoryDTO);
        CategoryResult categoryResult = new CategoryResult()
        {
            categoryId = categoryDTO.categoryId,
            categoryName = categoryDTO.categoryName,
        };
        return categoryResult;
    }
    public async Task<bool> DeleteCategory(int id)
    {
        return await _categoryRepository.DeleteCategory(id);
    }
    public async Task<bool> DeleteBooks(List<int> bookIds)
    {
        return await _bookRepository.DeleteBooksAsync(bookIds);
    }
    //Commentations
    public async Task<CommentationResult> CreateCommentation(CommentationType commentationType, int bookId, int userId)
    {
        Commentation commentDTO = new Commentation()
        {
            bookId = bookId,
            content = commentationType.content,
            ranK = commentationType.rank,
            userId = userId
        };
        commentDTO = await _commentationRepository.CreateCommentation(commentDTO);
        return new CommentationResult()
        {
            rank = commentDTO.ranK,
            content = commentDTO.content,
            userId = commentDTO.userId
        };
    }

    //CartDetails

    //Users
    public async Task<UserResult> Register(AppSellBook.Schema.Inputs.RegisterRequest registerRequest)
    {
        User userByUsername= await _userRepository.GetUserByName(registerRequest.Username);
        if (userByUsername != null)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 404,
                Message = "Tài khoản đã tồn tại. Vui lòng nhập tài khoản khác",
                Details = "Lỗi khi đã tồn tại 1 tài khoản"
            };
            throw new GraphQLException(errorResponse.Message);
        }
        var role = await _roleRepository.GetRoleById(1);
        string pass=_passwordHashser.HashPasswords(registerRequest.Password);
        User user = new User()
        {
            username = registerRequest.Username,
            password = pass,
        };
        user= await _userRepository.CreateUser(user);
        RoleUser roleUser = new RoleUser()
        {
            usersuserId = user.userId,
            rolesroleId = role.roleId
        };
        roleUser= await _roleUserRepository.CreateRoleUser(roleUser);
        return new UserResult()
        {
            userId=user.userId,
            username = user.username,
            password = user.password,
        };
    }
    public async Task<UserResult> Update(int userId,AppSellBook.Schema.Inputs.RegisterInfor registerInfor)
    {

        User user = new User()
        {
            userId= userId,
            email=registerInfor.email,
            gender=registerInfor.gender,
            phone=registerInfor.phone,
            firstName=registerInfor.firstName,
            lastName=registerInfor.lastName,
            dateOfBirth=registerInfor.dateOfBirth,
            point=0,
            purchaseAddress=registerInfor.purchaseAddress,
            deliveryAddress=registerInfor.deliveryAddress,
        };
        user = await _userRepository.UpdateUser(user);
        return new UserResult()
        {
            username = user.username,
            password = user.password,
        };
    }
    public async Task<UserResult> Login(AppSellBook.Schema.Inputs.LoginRequest loginRequest)
    {
        User userByUsername = await _userRepository.GetUserByName(loginRequest.username);
        if (userByUsername == null)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 404,
                Message = "Tài khoản không tồn tại!",
                Details = "Lỗi khi tìm kiếm tài khoản theo username."
            };
            throw new GraphQLException(errorResponse.Message);
        }
        bool isCorrectPass=_passwordHashser.VerifyPassword(loginRequest.password, userByUsername.password);
        if(!isCorrectPass)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 400,
                Message = "Mật khẩu không đúng!",
                Details = "Lỗi khi kiểm tra mật khẩu."
            };
            throw new GraphQLException(errorResponse.Message);
        }
        return new UserResult()
        {
            userId = userByUsername.userId,
            username = userByUsername.username,
            lastName=userByUsername.lastName,
            roleUsers=userByUsername.roleUsers.Select(r=>new RoleUserResult
            {
                rolesroleId=r.rolesroleId
            }).ToList(),
        };
    }
    public async Task<UserResult> GetPass(string username)
    {
        User user= await _userRepository.GetUserByName(username);
        if(user == null)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 404,
                Message = "Tài khoản không tồn tại!",
                Details = "Lỗi khi tìm kiếm tài khoản theo username."
            };
            throw new GraphQLException(errorResponse.Message);
        }

        return new UserResult()
        {
            userId = user.userId,
            username = user.username,
        };
    }
    public async Task<UserResult> UpdatePass(string username,string pass) {
        User user = await _userRepository.GetUserByName(username);
        user.password= _passwordHashser.HashPasswords(pass);
        user= await _userRepository.UpdatePass(user);
        return new UserResult()
        {
            userId = user.userId,
            username = user.username,
        };
    }
<<<<<<< HEAD
    //WishLists
=======
    //WishList
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    public async Task<WishListResult> AddWishlist(int userId,int bookId)
    {
        WishList wishListExist = await _wishListRepository.GetWishListByUserId(userId);
        if(wishListExist == null)
        {
            WishList wishList = new WishList()
            {
                userId = userId,
                wishListName = "Danh sách yêu thích"
            };
            wishListExist = await _wishListRepository.CreateWishList(wishList);
        }
        Book book = await _bookRepository.GetBookById(bookId);
        if(book == null)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 404,
                Message = "Sách không tồn tại",
                Details = "Lỗi khi thêm sách vào Wishlist"
            };
            throw new GraphQLException(errorResponse.Message);
        }
        bool exists = await _bookWishListRepository.existsInBookWishList(wishListExist.wishListId, book.bookId);
        if (exists)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 400,
                Message = "Sách đã tồn tại trong danh sách yêu thích",
                Details = "Sách này đã có trong Wishlist của bạn"
            };
            throw new GraphQLException(errorResponse.Message);
        }
        BookWishList bookWishList = new BookWishList()
        {
            wishListswishListId = wishListExist.wishListId,
            booksbookId = book.bookId
        };
        bookWishList= await _bookWishListRepository.CreateBookWishList(bookWishList);
        return new WishListResult()
        {
            wishListId = wishListExist.wishListId,
            userId = wishListExist.userId,
            wishListName = wishListExist.wishListName
        };
    }
<<<<<<< HEAD
    //Carts
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
    public async Task<CartResult> AddCart(int userId, int bookId)
    {
        User user= await _userRepository.GetUserById(userId);
        Cart cartExist= await _cartRepository.GetCartByUserId(userId);
        if (cartExist == null)
        {
            Cart cart = new Cart()
            {
                userId= userId,
                createDate = DateTime.Now,
                deliveryAddress=user.deliveryAddress,
                purchaseAddress=user.purchaseAddress
            };
            cartExist=await _cartRepository.CreateCard(cart);
        }
        Book book= await _bookRepository.GetBookById(bookId);
        if(book == null)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 404,
                Message = "Sách không tồn tại",
                Details = "Lỗi khi thêm sách vào Wishlist"
            };
            throw new GraphQLException(errorResponse.Message);
        }
        bool exists = await _cartDetailRepository.existsInCart(cartExist.cartId, book.bookId);
        if (exists)
        {
            var errorResponse = new ErrorResponse
            {
                StatusCode = 400,
                Message = "Sách đã tồn tại trong giỏ hàng",
                Details = "Sách này đã có trong Cart của bạn"
            };
            throw new GraphQLException(errorResponse.Message);
        }
        CartDetail cartDetail = new CartDetail()
        {
            cartId = cartExist.cartId,
            bookId = book.bookId,
            quantity = 1,
            sellPrice = book.sellPrice,
        };
        cartDetail= await _cartDetailRepository.CreateCartDetail(cartDetail);
        return new CartResult()
        {
            createDate = cartExist.createDate,
            userId = cartExist.userId,
            cartId = cartExist.cartId,
        };

    }
<<<<<<< HEAD
    //Orders
    public async Task<OrderResult> AddOrder(int userId)
    {
        Cart cartExist= await _cartRepository.GetCartByUserId(userId);
        Order order = new Order()
        {
            orderDate = DateTime.Now,
            userId = userId,
            orderStatus = "Processing",
            deliveryAddress = cartExist.deliveryAddress,
            purchaseAddress = cartExist.deliveryAddress,

        };
        order=await _orderRepository.CreateOrder(order);
        foreach(var carDetail in cartExist.cartDetails)
        {
            OrderDetail orderDetail = new OrderDetail()
            {
                orderId = order.orderId,
                bookId = carDetail.bookId,
                quantity = carDetail.quantity,
                sellPrice = carDetail.sellPrice
            };
            orderDetail= await _orderDetailRepository.CreateOrderDetail(orderDetail);
        }
        return new OrderResult()
        {
            orderId = order.orderId,
        };
    }
=======
>>>>>>> 38fd583bd06643b51a1d3a10c7ca9b6123963300
}
