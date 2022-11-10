using MagikarpService.Contracts.Data;

namespace MagikarpService.Repositories
{
    public interface IKarpTransactionRepository
    {
        Task<bool> CreateAsync(KarpTransactionDto karpTransaction);

        Task<KarpTransactionDto?> GetAsync(Guid id);

        Task<IEnumerable<KarpTransactionDto>> GetAllAsync();

        Task<bool> DeleteAsync(Guid id);
    }
}
