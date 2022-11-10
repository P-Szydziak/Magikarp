namespace MagikarpService.Contracts.Data
{
    public class KarpTransactionDto
    {
        public Guid Id { get; init; } = default!;
        public float Weight { get; init; } = default!;
        public short FishCount { get; init; } = default!;
        public DateTime CreatedAt { get; init; } = default!;
    }
}
