using System;

namespace DataModel.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; } = Guid.NewGuid();

        public DateTime CreatedUtc { get; } = DateTime.UtcNow;
    }
}