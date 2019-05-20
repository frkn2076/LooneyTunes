using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using LooneyTunes.Models;
using LooneyTunes.Query;
using Microsoft.AspNetCore.Mvc;

namespace LooneyTunes.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly AppDBContext context;

        public GraphQLController(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new CartoonSchema(context)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }


    }
}
