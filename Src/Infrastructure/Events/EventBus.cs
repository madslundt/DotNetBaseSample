using System;
using System.Threading.Tasks;
using Infrastructure.Outbox;
using MediatR;

namespace Infrastructure.Events
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IOutboxListener _outboxListener;

        public EventBus(IMediator mediator, IOutboxListener outboxListener = null)
        {
            _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
            _outboxListener = outboxListener;
        }

        public async Task Enqueue(params IEvent[] events)
        {
            foreach (var @event in events)
            {
                await _outboxListener.Commit(@event);
            }
        }

        public virtual async Task Commit(params IEvent[] events)
        {
            foreach (var @event in events)
            {   
                await Commit(@event);
            }
        }

        private async Task Commit(IEvent @event)
        {
            await _mediator.Publish(@event);
        }
    }
}