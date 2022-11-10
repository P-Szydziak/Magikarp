using MagikarpService.Contracts.Responses;
using MagikarpService.Models;

public static class DomainToApiContractMapper
{
    public static KarpTransactionResponse ToKarpTransactionResponse(this KarpTransaction karpTransaction)
    {
        return new KarpTransactionResponse
        {
            Id = karpTransaction.Id,
            Weight = karpTransaction.Weight,
            FishCount = karpTransaction.FishCount,
            CreatedAt = karpTransaction.CreatedAt,
        };
    }

    public static GetAllKarpTransactionsResponse ToKarpTransactionsResponse(this IEnumerable<KarpTransaction> karpTransactions)
    {
        return new GetAllKarpTransactionsResponse
        {
            KarpTransactions = karpTransactions.Select(karpTransaction => karpTransaction.ToKarpTransactionResponse())
        };
    }
}

