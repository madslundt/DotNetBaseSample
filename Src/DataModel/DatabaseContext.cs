using System;
using System.Threading;
using System.Threading.Tasks;
using DataModel.Models.UserIdentities;
using DataModel.Models.Users;
using DataModel.Models.Users.UserStatusRefs;
using Infrastructure.Events;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class DatabaseContext : DbContext
    {
        private readonly IEventBus _eventBus;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IEventBus eventBus = null) : base(options)
        {
            _eventBus = eventBus;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserIdentity> UserIdentities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            UserContext.Build(builder);
            UserStatusRefContext.Build(builder);
            UserIdentityContext.Build(builder);
        }

        [Obsolete("Use SaveChangesAsync(IEvent, CancellaionToken)", true)]
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveChangesAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            // await using var transaction = await Database.BeginTransactionAsync(cancellationToken);
            var result = await base.SaveChangesAsync(cancellationToken);
            await _eventBus.Commit(@event);
                
            // await transaction.CommitAsync(cancellationToken);

            return result;
        }
    }
}