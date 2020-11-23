using Shared.Models;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.DataProvider
{
    public class DirectApiService : IDataProviderService
    {
        private const string FINANCE_API_CURRENCY_JSON = "https://kurstoday.com/api/service/banks";

        private readonly HttpClient httpClient;

        public DirectApiService()
        {
            httpClient = new HttpClient();
        }

        public async Task<string> GetExchangeRatesAsync()
        {
            var responce =  await httpClient.GetAsync(FINANCE_API_CURRENCY_JSON).ConfigureAwait(false);
            return await responce.Content.ReadAsStringAsync();
        }
    }
}
