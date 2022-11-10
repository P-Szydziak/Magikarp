using MagikarpService.Models;

namespace MagikarpService.Services
{
    public interface IKarpTransactionService
    {
        Task<bool> CreateAsync(KarpTransaction karpTranasaction);

        Task<KarpTransaction?> GetAsync(Guid id);

        Task<IEnumerable<KarpTransaction>> GetAllAsync();

        Task<bool> DeleteAsync(Guid id);
    }
}
