using MagikarpService.Contracts.Data;
using MagikarpService.Models;

public static class DtoToDomainMapper
{
    public static KarpTransaction ToKarpTransaction(this KarpTransactionDto karpTransactionDto)
    {
        return new KarpTransaction
        {
            Id = karpTransactionDto.Id,
            Weight = karpTransactionDto.Weight,
            FishCount = karpTransactionDto.FishCount,
            CreatedAt = karpTransactionDto.CreatedAt,
        };
    }
}


