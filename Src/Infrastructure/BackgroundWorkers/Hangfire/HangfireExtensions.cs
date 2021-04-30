using Hangfire;
using Newtonsoft.Json;

namespace Infrastructure.BackgroundWorkers.Hangfire
{
    public static class HangfireExtensions
    {
        public static void UseHangfire(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}