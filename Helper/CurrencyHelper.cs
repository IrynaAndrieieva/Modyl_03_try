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
            string exchangeRateString = GetExchangeRate(minfinLink, CurrencyConstants.MINFIN_AUCTION_XPATH_EXPRESSION);
            double minfinExchangeRate = GetDouble(exchangeRateString);

            double monoExchangeRate = GetExchangeRateByISOCodeFromMono(monobankCurrencies, currencyA);

            CompareExchangeRates(minfinExchangeRate, monoExchangeRate, currencyA);
        }
        public string GetExchangeRate(string sourceLink, string xPathString)
        {
            var web = new HtmlWeb();
            var doc = web.Load(sourceLink);
            HtmlNode node = doc.DocumentNode.SelectSingleNode(xPathString);
            return node.InnerText;
        }
        public double GetDouble(string value)
        {
            double result;
            if (!double.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out result) &&
                !double.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                result = default;
            }
            return result;
        }
        public async Task<List<MonobankCurrencyInfo>> GetCurrencyExchangeRatesFromMono()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(CurrencyConstants.MONO_CURRENCIES_LINK);
                return JsonConvert.DeserializeObject<List<MonobankCurrencyInfo>>(json);
            }
        }
        public double GetExchangeRateByISOCodeFromMono(List<MonobankCurrencyInfo> monobankCurrencies, ISO4217Enum currencyA)
        {
            var currencyInfo = monobankCurrencies.First(c => c.currencyCodeA == (int)currencyA);
            return currencyInfo.rateBuy;
        }
        public void CompareExchangeRates(double monoExchangeRate, double minfinExchangeRate, ISO4217Enum currencyA)
        {
            Console.WriteLine($"{DateTime.Now}");
            Console.WriteLine($"BUYING RATES {ISO4217Enum.UAH} VS {currencyA}");
            Console.WriteLine($"MONO: {monoExchangeRate}");
            Console.WriteLine($"MINFIN: {minfinExchangeRate}");
            if (monoExchangeRate < minfinExchangeRate)
            {
                Console.WriteLine("It's time to rob caravans...");
            }
            if (monoExchangeRate == minfinExchangeRate)
            {
                Console.WriteLine("Time to rob caravans may come soon. Be ready...");
            }
            if (monoExchangeRate > minfinExchangeRate)
            {
                Console.WriteLine("Everething is fine. For now...");
            }
            Console.WriteLine();
        }
    }
}
