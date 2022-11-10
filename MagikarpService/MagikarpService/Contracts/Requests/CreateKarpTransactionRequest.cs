namespace MagikarpService.Contracts.Requests
{
    public class CreateKarpTransactionRequest
    {
        public float Weight { get; init; } = default!;
        public short FishCount { get; init; } = default!;
    }
}
