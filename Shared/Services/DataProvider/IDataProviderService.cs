using Shared.Models;

using System;
using System.Threading.Tasks;

namespace Shared.Services.DataProvider
{
    public interface IDataProviderService
    {
        Task<string> GetExchangeRatesAsync();
    }
}
