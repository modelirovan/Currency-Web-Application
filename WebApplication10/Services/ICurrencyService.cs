using System;
using System.Threading.Tasks;

namespace WebApplication10.Services
{
    public interface ICurrencyService
    {
        Task<Decimal> GetCurrencyExchangeAsync(String localCurrency, String foreignCurrency);
    }
}
