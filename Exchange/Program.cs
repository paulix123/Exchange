using System;
using System.Collections.Generic;

namespace Exchange
{
    class Program
    {

        static void Main(string[] args)
        {
            
            List<Currency> currencies = new List<Currency>
            {
                new Currency("Danish Krona", "DKK", 1),
                new Currency("Euro", "EUR", 7.4394),
                new Currency("Amerikanske dollar", "USD", 6.6311),
                new Currency("Britiske pund", "GBP", 8.5285),
                new Currency("Svenske kroner", "SEK", 0.7610),
                new Currency("Norske Kroner", "NOK", 0.7840),
                new Currency("Schweiziske franc", "CHF", 6.8358),
                new Currency("Japanske yen", "JPY", 0.05974)
            };

            
            if (args.Length == 2)
            {

                InputWrapper input = new InputWrapper();

                try
                {
                    input.CheckInput(args[0], args[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return;
                }

                var splited = input.ParseCurrencyPair(args[0]);

                try
                {
                    //Find needed currencies in predefined object list and fetch their rates
                    var main = currencies.Find(x => x.iso.Contains(splited[0])).rate;
                    var money = currencies.Find(x => x.iso.Contains(splited[1])).rate;

                    // x/y z - EUR/USD 20 - 20*EUR/USD - Calculate end result
                    var result = input.GetResult(main, money, Convert.ToDouble(args[1]));

                    Console.WriteLine(Math.Round(result, 4));
                }
                catch
                {
                    Console.WriteLine("Currency pair {0} {1} was not found, try again.", splited[0], splited[1]);
                    return;
                }

            }
            else
            {
                Console.WriteLine("Usage: Exchange <currency pair> <amount to exchange>");
                return;
            }
        }
    }
}
