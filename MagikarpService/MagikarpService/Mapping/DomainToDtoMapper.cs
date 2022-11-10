using MagikarpService.Contracts.Data;
using MagikarpService.Models;
using System.Net.Mail;

public static class DomainToDtoMapper
{
    public static KarpTransactionDto ToKarpTransactionDto(this KarpTransaction karpTransaction)
    {
        return new KarpTransactionDto
        {
            Id = karpTransaction.Id,
            Weight = karpTransaction.Weight,
            FishCount = karpTransaction.FishCount,
            CreatedAt = karpTransaction.CreatedAt,
        };
    }
}


