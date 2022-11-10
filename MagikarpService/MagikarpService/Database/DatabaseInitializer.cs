using Dapper;

namespace Customers.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS KarpTransactions (
                                        Id UUID PRIMARY KEY, 
                                        Weight REAL NOT NULL,
                                        FishCount SMALLINT NOT NULL,
                                        CreatedAt TIMESTAMP NOT NULL)");
    }
}
