using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public static class CurrencyRatesMono
    {
        public static async Task<List<MonobankCurrencyInfo>> GetCurrencyExchangeRatesFromMono()
        {
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(CurrencyConstants.MONO_CURRENCIES_LINK);
                return JsonConvert.DeserializeObject<List<MonobankCurrencyInfo>>(json);
            }
        }
    }
}
