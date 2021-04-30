using Hangfire;

namespace Infrastructure.BackgroundWorkers.Hangfire
{
    public class HangfireOptions : DashboardOptions
    {
        public string Path { get; set; } = "/hangfire";
    }
}