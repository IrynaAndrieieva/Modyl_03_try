using Modyl_03_try.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public static class RateByISOCodeMono
    {
        public static double GetExchangeRateByISOCodeFromMono(List<MonobankCurrencyInfo> monobankCurrencies, ISO4217Enum currencyA)
        {
            var currencyInfo = monobankCurrencies.First(c => c.currencyCodeA == (int)currencyA);
            return currencyInfo.rateBuy;
        }
    }
}
