using System.ComponentModel;
using System.Threading.Tasks;
using MediatR;

namespace Infrastructure.BackgroundWorkers.Hangfire
{
    public class MediatorHangfireBridge
    {
        private readonly IMediator _mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Enqueue(IBackgroundJob request)
        {
            await _mediator.Publish(request);
        }

        [DisplayName("{0}")]
        public async Task Enqueue(string jobName, IBackgroundJob request)
        {
            await _mediator.Publish(request);
        }
    }
}