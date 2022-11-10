using MagikarpService.Contracts.Requests;
using MagikarpService.Models;
using System.Net.Mail;

namespace MagikarpService.Mapping
{
    public static class ApiContractToDomainMapper
    {
        public static KarpTransaction ToKarpTransaction(this CreateKarpTransactionRequest request)
        {
            return new KarpTransaction
            {
                Id = Guid.NewGuid(),
                Weight = request.Weight,
                FishCount = request.FishCount,
                CreatedAt = DateTime.UtcNow
            };
        }
    }
}

