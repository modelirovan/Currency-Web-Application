using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Currency.DAL.Repositories
{
    public interface ICurrencyRepository
    {
        Task<List<Currency.DAL.Models.Currency>> GetCurrenciesByPeriod(TimeSpan timeSpan);
    }
}
