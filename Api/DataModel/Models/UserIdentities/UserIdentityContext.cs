using Microsoft.EntityFrameworkCore;

namespace DataModel.Models.UserIdentities
{
    public class UserIdentityContext
    {
        public static void Build(ModelBuilder builder)
        {
            builder.Entity<UserIdentity>(b =>
            {
                b.AddBaseModelContext();

                b.Property(p => p.FirstName)
                    .IsRequired();

                b.Property(p => p.LastName)
                    .IsRequired();

                b.Property(p => p.Email)
                    .IsRequired();

                b.HasIndex(k => k.Email)
                    .IsUnique();

                b.HasOne(r => r.User)
                    .WithOne(r => r.Identity)
                    .HasForeignKey<UserIdentity>(fk => fk.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();
            });
        }
    }
}