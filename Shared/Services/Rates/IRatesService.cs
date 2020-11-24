using Shared.Models;
using Shared.Models.DTO;

using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Shared.Services.Rates
{
    public interface IRatesService
    {
        ReadOnlyDictionary<BankId, Bank> Banks { get; }
        Task UpdateRatesInfoAsync();
        CurrencyRates GetAvarageRates();
    }
}
