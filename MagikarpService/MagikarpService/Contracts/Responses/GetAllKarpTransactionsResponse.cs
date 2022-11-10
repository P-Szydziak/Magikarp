namespace MagikarpService.Contracts.Responses
{
    public class GetAllKarpTransactionsResponse
    {
        public IEnumerable<KarpTransactionResponse> KarpTransactions { get; init; } = Enumerable.Empty<KarpTransactionResponse>();
    }
}
