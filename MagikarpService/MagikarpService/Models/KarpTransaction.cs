namespace MagikarpService.Models
{
    public class KarpTransaction
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public float Weight { get; init; } = default!;
        public short FishCount { get; init; } = default!;
        public DateTime CreatedAt { get; init; } = default!;
    }
}