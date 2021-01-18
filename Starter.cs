using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modyl_03_try
{
    public static class Starter
    {
        public static void Run()
        {
            while (true)
            {
                Comparer.RatesComparer();

                // задержка необходима для того, что иначе выбивает 429 ошибку - слишком частое обращение к сайту
                System.Threading.Thread.Sleep(60000);
            }                               
        }
    }
}
