using AutoMapper;
using Microsoft.Extensions.Hosting;
using Wassandashboard.Data;
using Wassandashboard.Data.Services;
using Wassandashboard.Services;

namespace Wassandashboard.Jobs
{
    public class DataPushService : IHostedService, IDisposable
    {
        private readonly ILogger<DataPushService> _logger;
        private Timer _timer;
        private readonly IServiceProvider _serviceProvider;
        public DataPushService(ILogger<DataPushService> logger,
                               IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Data Push Service is starting.");

            // Run the timer to execute the task every hour
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(1));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation("Data Push Service is working.");

            //todo: add Logic Here
            using (var scope = _serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var subService = services.GetRequiredService<SubmissionsService>();
                var dbContext = services.GetRequiredService<DashboardDbContext>();
                var mapper = services.GetRequiredService<IMapper>();
                var odkService = new OdkDataPushService(subService, dbContext, mapper);
            }
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Data Push Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
