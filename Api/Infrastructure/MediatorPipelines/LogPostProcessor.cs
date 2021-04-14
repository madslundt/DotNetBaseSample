using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Infrastructure.MediatorPipelines
{
    public class LogPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public LogPostProcessor(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handled {typeof(TRequest).FullName}", new
            {
                Request = request,
                Response = response
            });

            return Task.CompletedTask;
        }
    }
}