using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Models
{
    public static class BaseModelContextExtensions
    {
        public static void AddBaseModelContext<T>(this EntityTypeBuilder<T> baseModel) where T : BaseModel
        {
            baseModel.Property(p => p.Id)
                .IsRequired();

            baseModel.Property(p => p.CreatedUtc)
                .IsRequired();

            baseModel.HasKey(k => k.Id);
        }
    }
}