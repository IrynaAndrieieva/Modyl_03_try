using Modyl_03_try.Enums;
using Modyl_03_try.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public static class Comparer
    {
        public static void RatesComparer()
        {

            try
            {
                CurrencyHelper ch = new CurrencyHelper();
                var monoCurrencyExchangeRates = ch.GetCurrencyExchangeRatesFromMono().Result;
                ch.CompareRates(monoCurrencyExchangeRates, CurrencyConstants.MINFIN_AUCTION_LINK_UAH_TO_USD, ISO4217Enum.USD);
                ch.CompareRates(monoCurrencyExchangeRates, CurrencyConstants.MINFIN_AUCTION_LINK_UAH_TO_EUR, ISO4217Enum.EUR);
            }
            catch (Exception ex) // на случай, если все равно несмотря на задержку в стартере выбъет ошибку 429, чтобы программа не вылетала
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("429"))
                {
                    System.Threading.Thread.Sleep(60000);
                }
                else
                {
                    Console.WriteLine($"Application stopped with exception: {ex.Message}");
                }
            }
        }
    }
}
