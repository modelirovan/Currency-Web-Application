using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApplication10.Services;

namespace WebApplication10.BackgroundWorkers
{
    public class CurrencyBackgroundWorker : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ICurrencyService _currencyService;

        public CurrencyBackgroundWorker(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _currencyService.GetCurrencyExchangeAsync("USD_PHP", "PHP_USD");
        }
    }
}
