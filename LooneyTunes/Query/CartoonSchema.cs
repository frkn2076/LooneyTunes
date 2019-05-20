using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using LooneyTunes.Models;

namespace LooneyTunes.Query
{
    public class CartoonSchema : ObjectGraphType
    {
        public CartoonSchema(AppDBContext db)
        {
            //Get by id or name
            Field<CartoonType>("cartoon",
                arguments: new QueryArguments(
                    new List<QueryArgument> {
                        new QueryArgument<IdGraphType>
                        {
                            Name = "id", Description = "The ID of the cartoon."
                        },
                        new QueryArgument<StringGraphType>
                        {
                            Name = "name", Description = "The name of the cartoon"
                        }
                    }),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");
                    var name = context.GetArgument<string>("name");
                    if (id.HasValue)
                    {
                        var cartoon = db.Cartoons.FirstOrDefault(x => x.CartoonId == id);
                        return cartoon;
                    }
                    if (name != null)
                    {
                        return db.Cartoons.FirstOrDefault(x => x.Name == name);
                    }

                    return db.Cartoons;
                }
            );


            //Get all
            Field<ListGraphType<CartoonType>>("cartoons",
                resolve: context =>
                {
                    var cartoons = db.Cartoons;
                    return cartoons;
                }
            );
        }
    }
}
