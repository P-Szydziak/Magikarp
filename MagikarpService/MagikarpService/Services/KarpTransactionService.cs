using MagikarpService.Models;
using MagikarpService.Repositories;

namespace MagikarpService.Services
{
    public class KarpTransactionService : IKarpTransactionService
    {
        private readonly IKarpTransactionRepository _karpTransactionRepository;

        public KarpTransactionService(IKarpTransactionRepository karpTransactionRepository)
        {
            _karpTransactionRepository = karpTransactionRepository;
        }

        public async Task<bool> CreateAsync(KarpTransaction karpTranasaction)
        {
            var karpTransactionDto = karpTranasaction.ToKarpTransactionDto();
            return await _karpTransactionRepository.CreateAsync(karpTransactionDto);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _karpTransactionRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<KarpTransaction>> GetAllAsync()
        {
            var karpTransactionDtos = await _karpTransactionRepository.GetAllAsync();
            return karpTransactionDtos.Select(x => x.ToKarpTransaction());
        }

        public async Task<KarpTransaction?> GetAsync(Guid id)
        {
            var karpTransactionDto = await _karpTransactionRepository.GetAsync(id);
            return karpTransactionDto?.ToKarpTransaction();
        }
    }
}
