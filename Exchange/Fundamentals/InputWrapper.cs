using System;

namespace Exchange
{
    public class InputWrapper
    {

        public double GetResult(double main, double money, double exAmount)
        {
            var result = exAmount * main / money;
            return result;
        }

        public string[] ParseCurrencyPair(string currPair)
        {
            var splited = currPair.Split('/');
            return splited;
        }

        public void CheckInput(string currPair, string exAmount)
        {
            if (currPair.Split('/').Length != 2 || currPair.Length != 7)
            {
                throw new ArgumentException("Currencies are not entered correctly. Please try again");
            }

            if (Double.Parse(exAmount) <= 0)
            {
                throw new ArgumentException("Enter valid exchange amount (>0)");
            }
        }
    }
}
