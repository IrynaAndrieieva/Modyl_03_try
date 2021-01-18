using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{  
    public static class CurrencyConstants //all our links from which we take information and X-path
    {
        public static string MINFIN_AUCTION_LINK_UAH_TO_USD = "https://minfin.com.ua/currency/auction/usd/buy/kharkov/";
        public static string MINFIN_AUCTION_LINK_UAH_TO_EUR = "https://minfin.com.ua/currency/auction/eur/buy/kharkov/";
        public static string MINFIN_AUCTION_XPATH_EXPRESSION = "//*[@id=\"exchanges-page-container\"]/div[1]/div[1]/div[3]/div/div/div[1]/span/text()";

        public static string MONO_CURRENCIES_LINK = "https://api.monobank.ua/bank/currency";
    }
}
