namespace MagikarpService.Contracts.Responses
{
    public class KarpTransactionResponse
    {
        public Guid Id { get; init; }
        public float Weight { get; init; }
        public short FishCount { get; init; } = default!;
        public DateTime CreatedAt { get; init; }
    }
}
