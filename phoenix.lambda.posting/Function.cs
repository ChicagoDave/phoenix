using System.Linq;
using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Neo4j.Driver;
using phoenix.graph.repositories;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace phoenix.lambda.posting;

public class Function
{
    private DataContext dataContext = new graph.repositories.DataContext();
    
    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string FunctionHandler(string input, ILambdaContext context)
    {
        return input.ToUpper();
    }

    public async Task FindPerson(string personName)
    {
        var query = @"
        MATCH (p:Person)
        WHERE p.name = $name
        RETURN p.name";

        await using var session = _driver.AsyncSession(configBuilder => configBuilder.WithDatabase("neo4j"));
        try
        {
            var readResults = await session.ExecuteReadAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new { name = personName });
                return await result.ToListAsync();
            });

            foreach (var result in readResults)
            {
                Console.WriteLine($"Found person: {result["p.name"].As<String>()}");
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
    }
}
