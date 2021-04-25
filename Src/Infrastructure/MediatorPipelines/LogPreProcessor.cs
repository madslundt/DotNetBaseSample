using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Infrastructure.MediatorPipelines
{
    public class LogPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
        {
            private readonly ILogger<TRequest> _logger;
    
            public LogPreProcessor(ILogger<TRequest> logger)
            {
                _logger = logger;
            }
    
            public Task Process(TRequest request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Handling {typeof(TRequest).FullName}", new
                {
                    Request = request
                });

                return Task.CompletedTask;
            }
        }
}