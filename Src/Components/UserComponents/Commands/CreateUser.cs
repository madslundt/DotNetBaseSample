using System;
using System.Threading;
using System.Threading.Tasks;
using DataModel;
using DataModel.Models.UserIdentities;
using DataModel.Models.Users;
using Events.UserEvents;
using FluentValidation;
using Infrastructure.Commands;

namespace Components.UserComponents.Commands
{
    public class CreateUser
    {
        public class Command : ICommand<Result>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
        }

        public class Validator : AbstractValidator<Command>
        {
            public Validator()
            {
                RuleFor(command => command.FirstName).NotEmpty();
                RuleFor(command => command.LastName).NotEmpty();
                RuleFor(command => command.Email).NotEmpty().EmailAddress();
            }
        }

        public class Result
        {
            public Guid Id { get; set; }
        }

        public class Handler : ICommandHandler<Command, Result>
        {
            private readonly DatabaseContext _db;

            public Handler(DatabaseContext db)
            {
                _db = db;
            }

            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = AddUser(request);

                var @event = new UserCreatedEvent(user.Id);
                await _db.SaveChangesAsync(@event, cancellationToken);

                var result = new Result
                {
                    Id = user.Id
                };

                return result;
            }

            private User AddUser(Command request)
            {
                var user = new User
                {
                    FirstName = request.FirstName,
                    Identity = new UserIdentity
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email
                    }
                };

                _db.Add(user);

                return user;
            }
        }
    }
}