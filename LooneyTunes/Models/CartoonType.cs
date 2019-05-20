using GraphQL.Types;

namespace LooneyTunes.Models
{
    public class CartoonType : ObjectGraphType<Cartoon>
    {
        public CartoonType()
        {
            Name = "Cartoon";

            Field(x => x.CartoonId, type: typeof(IdGraphType)).Description("Unique Id");
            Field(x => x.Name).Description("Name of the cartoon");
            Field(x => x.Image).Description("Image of the cartoon");
            Field(x => x.Description).Description("Details of the cartoon");
        }
    }
}
