using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Shared.Models;
using Shared.Models.DTO;
using Shared.Services.DataProvider;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Rates
{
    public class RatesService : IRatesService
    {
        private IDataProviderService _dataProviderService;

        public ReadOnlyDictionary<BankId, Bank> Banks { get; private set; }

        public RatesService(IDataProviderService dataProviderService)
        {
            _dataProviderService = dataProviderService;
        }

        public async Task UpdateRatesInfoAsync()
        {
            var data = await GetRatesAsync().ConfigureAwait(false);
            Banks = CreateBanksDictionary(data);
        }

        private async Task<string> GetRatesAsync()
        {
            return await _dataProviderService.GetExchangeRatesAsync().ConfigureAwait(false);
        }

        private ReadOnlyDictionary<BankId, Bank> CreateBanksDictionary(string data)
        {
            var jobject = JObject.Parse(data)["exchangers"];
            Dictionary<BankId, Bank> output = new Dictionary<BankId, Bank>();
            List<Bank> banks = new List<Bank>();

            try
            {
                banks = jobject.ToObject<List<Bank>>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            foreach (var bank in banks)
            {
                output.Add((BankId)bank.Id, bank);
            }

            return new ReadOnlyDictionary<BankId, Bank>(output);
        }

        public CurrencyRates GetAvarageRates()
        {
            CurrencyRates output = new CurrencyRates();

            foreach (var bank in Banks)
            {
                CurrencyRates rates = bank.Value.CurrencyRates;

                foreach (PropertyInfo property in rates.GetType().GetProperties())
                {
                    if (property.PropertyType.Equals(typeof(Currency)))
                    {
                        Currency value = (Currency)property.GetValue(rates);
                        Currency currentValue = (Currency)property.GetValue(output);

                        if (currentValue != null)
                        {
                            Currency newValue = new Currency();

                            newValue.Purchase = (currentValue.Purchase + value.Purchase) / 2;
                            newValue.Sell = (currentValue.Sell + value.Sell) / 2;

                            property.SetValue(output, newValue);
                        }
                        else
                        {
                            property.SetValue(output, value);
                        }
                    }
                }
            }

            return output;
        }
    }
}
