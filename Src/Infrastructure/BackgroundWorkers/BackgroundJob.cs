using System;

namespace Infrastructure.BackgroundWorkers
{
    public abstract class BackgroundJob : IBackgroundJob
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedUtc { get; } = DateTime.UtcNow;
    }
}