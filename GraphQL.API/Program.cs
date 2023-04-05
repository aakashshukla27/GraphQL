using GraphQL.API.Schema;

namespace GraphQL.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddGraphQLServer().AddQueryType<Query>();
            var app = builder.Build();

            app.MapGraphQL();

            app.Run();
        }
    }
}