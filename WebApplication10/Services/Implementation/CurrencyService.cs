using Currency.DAL.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication10.Services.Implementation
{
    public class CurrencyService : ICurrencyService
    {
        private readonly String BASE_URI = "https://free.currconv.com";
        private readonly String API_VERSION = "v7";
        private readonly string API_Key = "6d47290585cfcb4b6ac7";
        static HttpClient client = new HttpClient();
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public CurrencyService(
            IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
           
        }

        public async Task<decimal> GetCurrencyExchangeAsync(string localCurrency, string foreignCurrency)
        {
            var code = $"{localCurrency},{foreignCurrency}";
            var newRate = await FetchSerializedDataAsync(code);
            return newRate;
        }

        private async Task<decimal> FetchSerializedDataAsync(string code)
        {
            var url = $"{BASE_URI}/api/{API_VERSION}/convert?q={code}&compact=ultra&apiKey={API_Key}";
            var jsonData = String.Empty;

            var conversionRate = 1.0m;

            using(var webClient = new WebClient())
	        {
                 try
                {
                 jsonData = webClient.DownloadString(url);
                var jsonObject = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(jsonData); 

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<CurrencyContext>();

                    foreach (var item in jsonObject)
                    {
                        var currency = new Currency.DAL.Models.Currency
                        {
                            CurrencyName = item.Key,
                            Rate = item.Value,
                            RowCreatedDate = DateTime.Now
                        };

                        dbContext.Set<Currency.DAL.Models.Currency>().Add(currency);
                        await dbContext.SaveChangesAsync();
                    }
                }
                }
                    catch (Exception ex)
                  {
                //Logging error
                  }
	        }
           

            return conversionRate;
        }
    }
}
