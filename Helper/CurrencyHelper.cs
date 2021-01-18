using HtmlAgilityPack;
using Modyl_03_try.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try.Helper
{
    public class CurrencyHelper
    {
        public void CompareRates(List<MonobankCurrencyInfo> monobankCurrencies, string minfinLink, ISO4217Enum currencyA)
        {
            string exchangeRateString = ExchangeRateWeb.GetExchangeRate(minfinLink, CurrencyConstants.MINFIN_AUCTION_XPATH_EXPRESSION);
            double minfinExchangeRate = ParsingDouble.GetDouble(exchangeRateString);

            double monoExchangeRate = RateByISOCodeMono.GetExchangeRateByISOCodeFromMono(monobankCurrencies, currencyA);

            CompareExchangeRates(minfinExchangeRate, monoExchangeRate, currencyA);
        }
        
        public void CompareExchangeRates(double monoExchangeRate, double minfinExchangeRate, ISO4217Enum currencyA)
        {
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"BUYING RATES {ISO4217Enum.UAH} VS {currencyA}");
            Console.WriteLine($"MONO: {monoExchangeRate}");
            Console.WriteLine($"MINFIN: {minfinExchangeRate}");

            if (monoExchangeRate < minfinExchangeRate)
            {
                Console.WriteLine("It's time to rob caravans! ");
            }
            else if (monoExchangeRate == minfinExchangeRate)
            {
                Console.WriteLine("Time to rob caravans may come soon. Be ready...");
            }
            else
            {
                Console.WriteLine("Everething is fine. For now...");
            }
            Console.WriteLine();
        }
    }
}
