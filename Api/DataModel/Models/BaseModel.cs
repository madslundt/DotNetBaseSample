using System;

namespace DataModel.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}