using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace GetCurrencyRatesFunction
{
    public static class GetCurrenciesRates
    {
        [FunctionName("GetCurrenciesRates")]
        public static Task Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log,
                                [SignalR(HubName = "currencyinfo")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            log.LogInformation($"GetCurrenciesRates executed at: {DateTime.Now}");

            ApiService apiService = new ApiService();

            var currenciesRates = apiService.GetCurrenciesRates();
            var officialRates = apiService.GetOfficialRates();

            return signalRMessages.AddAsync(
        new SignalRMessage
        {
            Target = "CurrencyInfo",
            Arguments = new[] { currenciesRates, officialRates }
        });
        }
    }
}
