using Currency.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Currency.DAL.Repositories.Implementation
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _currencyContext;

        public CurrencyRepository(CurrencyContext currencyContext)
        {
            _currencyContext = currencyContext;
        }

        public async Task<List<Models.Currency>> GetCurrenciesByPeriod(TimeSpan timeSpan)
        {
            var datePeriod = DateTime.Now - timeSpan;
            var res = _currencyContext.Currencies.Where(x => x.RowCreatedDate > datePeriod).ToList();
            return res;
        }
    }
}
