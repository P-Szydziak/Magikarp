using Customers.Api.Database;
using Dapper;
using MagikarpService.Contracts.Data;

namespace MagikarpService.Repositories
{
    public class KarpTransactionRepository : IKarpTransactionRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public KarpTransactionRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> CreateAsync(KarpTransactionDto karpTransaction)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(
                @"INSERT INTO KarpTransactions (Id, Weight, FishCount, CreatedAt) 
            VALUES (@Id, @Weight, @FishCount, @CreatedAt)",
                karpTransaction);
            return result > 0;
        }

        public async Task<KarpTransactionDto?> GetAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QuerySingleOrDefaultAsync<KarpTransactionDto>(
                "SELECT * FROM KarpTransactions WHERE Id = @Id LIMIT 1", new { Id = id });
        }

        public async Task<IEnumerable<KarpTransactionDto>> GetAllAsync()
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            return await connection.QueryAsync<KarpTransactionDto>("SELECT * FROM KarpTransactions");
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            var result = await connection.ExecuteAsync(@"DELETE FROM KarpTransactions WHERE Id = @Id",
                new { Id = id });
            return result > 0;
        }
    }
}
