using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace videostore_be.service
{
    public class HangfireBackgroundService : IHostedService
    {
        private readonly IHangfireService _hangfireService;

        public HangfireBackgroundService(IHangfireService hangfireService)
        {
            _hangfireService = hangfireService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Run(() => _hangfireService.EnqueueSampleJob());
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}