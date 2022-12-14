using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using phoenix.domains;
using System.ComponentModel;

public class DriverIntroductionExample : IDisposable
{
    private bool _disposed = false;
    private readonly IDriver _driver;

    ~DriverIntroductionExample() => Dispose(false);

    public DriverIntroductionExample()
    {
        Settings.Load();
        _driver = GraphDatabase.Driver(Settings.Neo4jSettings.neo4jURI, AuthTokens.Basic(Settings.Neo4jSettings.neo4jUser, Settings.Neo4jSettings.neo4jPassword));
    }

    public async Task CreateFriendship(string person1Name, string person2Name)
    {
        // To learn more about the Cypher syntax, see https://neo4j.com/docs/cypher-manual/current/
        // The Reference Card is also a good resource for keywords https://neo4j.com/docs/cypher-refcard/current/
        var query = @"
        MERGE (p1:Person { name: $person1Name })
        MERGE (p2:Person { name: $person2Name })
        MERGE (p1)-[:Follows]->(p2)
        RETURN p1, p2";

        await using var session = _driver.AsyncSession(configBuilder => configBuilder.WithDatabase("neo4j"));
        try
        {
            // Write transactions allow the driver to handle retries and transient error
            var writeResults = await session.ExecuteWriteAsync(async tx =>
            {
                var result = await tx.RunAsync(query, new { person1Name, person2Name });
                return await result.ToListAsync();
            });

            foreach (var result in writeResults)
            {
                var person1 = result["p1"].As<INode>().Properties["name"];
                var person2 = result["p2"].As<INode>().Properties["name"];
                Console.WriteLine($"Created friendship between: {person1}, {person2}");
            }
        }
        // Capture any errors along with the query and data for traceability
        catch (Neo4jException ex)
        {
            Console.WriteLine($"{query} - {ex}");
            throw;
        }
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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            _driver?.Dispose();
        }

        _disposed = true;
    }

    public static async Task Main(string[] args)
    {
        using var example = new DriverIntroductionExample();
        await example.CreateFriendship("David", "Sabrina");
        await example.FindPerson("Sabrina");
    }
}