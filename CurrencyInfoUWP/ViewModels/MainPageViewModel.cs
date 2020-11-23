using Shared.Models;
using Shared.Services;
using Shared.Services.DataProvider;
using Shared.Services.Rates;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CurrencyInfoUWP.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IDataProviderService _dataProviderService;
        private readonly IRatesService _ratesService;

        public string DollarPurchaseRate { get; set; }
        public string DollarSellRate { get; set; }
        public string EuroPurchaseRate { get; set; }
        public string EuroSellRate { get; set; }
        public string OfficialExchangeRate { get; set; }

        public RelayCommand UpdateCommand { get; private set; }

        public MainPageViewModel(IDataProviderService dataProviderService, IRatesService ratesService)
        {
            _dataProviderService = dataProviderService;
            _ratesService = ratesService;

            //TODO: need to get init out of c-tor
            InitializeAsync().Wait();

            UpdateCommand = new RelayCommand(CanUpdateRates, UpdateRates);
        }
        public override async Task InitializeAsync()
        {
            if (_ratesService.Banks == null)
            {
                await _ratesService.UpdateRatesInfoAsync().ConfigureAwait(false);
            }

            var selectedBank = _ratesService.Banks[BankId.Aval];
            var nbu = _ratesService.Banks[BankId.NBU];

            DollarPurchaseRate = selectedBank.CurrencyRates.USD.Purchase.ToString();
            DollarSellRate = selectedBank.CurrencyRates.USD.Sell.ToString();
            EuroPurchaseRate = selectedBank.CurrencyRates.EUR.Purchase.ToString();
            EuroSellRate = selectedBank.CurrencyRates.EUR.Sell.ToString();

            OfficialExchangeRate = nbu.CurrencyRates.PLN.Purchase.ToString();
        }

        public void UpdateRates()
        {
            UpdateExecute().Wait();
        }

        private bool CanUpdateRates()
        {
            return true;
        }

        private async Task UpdateExecute()
        {
            await _ratesService.UpdateRatesInfoAsync().ConfigureAwait(false);
        }
    }
}
