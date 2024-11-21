using GraphQL.Types;
namespace AppSellBook.Schema.Inputs
{
    public class BookTypeInput : InputObjectGraphType
    {
        public BookTypeInput()
        {
            Name = "BookTypeInput";

            // Định nghĩa các trường cần thiết trong BookTypeInput
            Field<NonNullGraphType<StringGraphType>>("bookName");
            Field<StringGraphType>("ISBN");
            Field<NonNullGraphType<FloatGraphType>>("listedPrice");
            Field<NonNullGraphType<FloatGraphType>>("sellPrice");
            Field<NonNullGraphType<IntGraphType>>("quantity");
            Field<StringGraphType>("description");
            Field<StringGraphType>("author");
            Field<FloatGraphType>("rank");
            Field<ListGraphType<ImageTypeInput>>("images");
            // Nếu bạn muốn hỗ trợ các mối quan hệ như categories, images thì cũng cần định nghĩa tương tự
            //Field<ListGraphType<CategoryTypeInput>>("categories");
            //Field<ListGraphType<ImageTypeInput>>("images");
            //Field<ListGraphType<CartDetailTypeInput>>("cartDetails");
            //Field<ListGraphType<OrderDetailTypeInput>>("orderDetails");
            //Field<ListGraphType<WishListTypeInput>>("wishLists");
            //Field<ListGraphType<CommentationTypeInput>>("commentations");
        }
    }
}
