using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class RateChangeEventArgs
    {
        public string ExchangeRates { get; }

        public RateChangeEventArgs(string exchangeRates)
        {
            ExchangeRates = exchangeRates;
        }
    }
}
