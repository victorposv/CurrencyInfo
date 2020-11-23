using Microsoft.Build.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GetCurrencyRatesFunction
{
    public class ApiService
    {
        private const string NBU_API_CURRENCY_XML = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange";
        private const string NBU_API_CURRENCY_JSON = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
        private const string FINANCE_API_CURRENCY_XML = "http://resources.finance.ua/ua/public/currency-cash.xml";
        private const string FINANCE_API_CURRENCY_JSON = "http://resources.finance.ua/ua/public/currency-cash.json";

        private HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public string GetCurrenciesRates()
        {
            var responce = httpClient.GetAsync(FINANCE_API_CURRENCY_JSON).Result;

            if (!responce.IsSuccessStatusCode)
                responce = httpClient.GetAsync(FINANCE_API_CURRENCY_XML).Result;

            return responce.Content.ReadAsStringAsync().Result;
        }

        public string GetOfficialRates()
        {
            var responce = httpClient.GetAsync(NBU_API_CURRENCY_JSON).Result;

            if (!responce.IsSuccessStatusCode)
                responce = httpClient.GetAsync(NBU_API_CURRENCY_XML).Result;

            return responce.Content.ReadAsStringAsync().Result;
        }
    }
}
