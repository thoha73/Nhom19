using GraphQL.Types;

namespace AppSellBook.Schema.Inputs
{
        public class ImageTypeInput : InputObjectGraphType
        {
            public ImageTypeInput()
            {
                Name = "ImageTypeInput";
                Field<NonNullGraphType<StringGraphType>>("imageName");
                Field<NonNullGraphType<StringGraphType>>("imageData");
                Field<NonNullGraphType<BooleanGraphType>>("icon");
            }
        
        }
}
