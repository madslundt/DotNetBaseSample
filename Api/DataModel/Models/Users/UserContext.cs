﻿using Microsoft.EntityFrameworkCore;

namespace DataModel.Models.Users
{
    public class UserContext
    {
        public static void Build(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.Property(p => p.Id)
                    .IsRequired();

                b.Property(p => p.FirstName)
                    .IsRequired();

                b.HasOne(r => r.StatusRef)
                    .WithMany()
                    .HasForeignKey(fk => fk.Status)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                b.HasKey(k => k.Id);
            });
        }
    }
}