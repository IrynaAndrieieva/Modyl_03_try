using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public static class ExchangeRateWeb //gets exchange rate from links
    {
        public static string GetExchangeRate(string sourceLink, string xPathString)
        {
            var web = new HtmlWeb();
            var doc = web.Load(sourceLink);
            HtmlNode node = doc.DocumentNode.SelectSingleNode(xPathString);
            return node.InnerText;
        }
    }
}
