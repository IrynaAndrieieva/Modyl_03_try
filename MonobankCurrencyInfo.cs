using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public class MonobankCurrencyInfo //data taken from the sitehttps://api.monobank.ua/docs/ section CurrencyInfo: array
    {
        //Код валюти рахунку відповідно ISO 4217
        public int currencyCodeA { get; set; }
        //Код валюти рахунку відповідно ISO 4217
        public int currencyCodeB { get; set; }
        //Час курсу в секундах в форматі Unix time
        public int date { get; set; }
        public double rateSell { get; set; }
        public double rateBuy { get; set; }
        public double rateCross { get; set; }
    }
}
