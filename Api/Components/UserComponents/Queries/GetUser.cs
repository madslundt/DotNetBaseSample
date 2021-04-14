using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel;
using FluentValidation;
using Infrastructure.Queries;
using Microsoft.EntityFrameworkCore;

namespace Components.UserComponents.Queries
{
    public class GetUser
    {
        public class Query : IQuery<Result>
        {
            public Guid UserId { get; set; }
        }

        public class Validator : AbstractValidator<Query>
        {
            public Validator()
            {
                RuleFor(query => query.UserId).NotEmpty();
            }
        }

        public class Result
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class Handler : IQueryHandler<Query, Result>
        {
            private readonly DatabaseContext _db;

            public Handler(DatabaseContext db)
            {
                _db = db;
            }
            
            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await GetUser(request.UserId, cancellationToken);

                if (result is null)
                {
                    throw new ArgumentNullException($"Company was not found with id '{request.UserId}'");
                }

                return result;
            }

            private async Task<Result> GetUser(Guid id, CancellationToken cancellationToken)
            {
                var query = from user in _db.Users
                    join identity in _db.UserIdentities on user.Id equals identity.UserId
                    where user.Id == id
                    select new Result
                    {
                        FirstName = identity.FirstName,
                        LastName = identity.LastName,
                        Email = identity.Email
                    };

                var result = await query.FirstOrDefaultAsync(cancellationToken);

                return result;
            }
        }
    }
}