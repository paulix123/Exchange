using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Exchange.UnitTests
{
    [TestClass]
    public class CurrenciesTest
    {
        [TestMethod]
        public void GetResult_CorrectValues_ReturnsResult()
        {
            //Lets find out if result is returned in correct type
            //Arrange
            var currency = new Currency("Euro", "EUR", 7.4394);
            var currency2 = new Currency("Dollar", "USD", 6.2487);
            var amount = 20;
            var input = new InputWrapper();

            //Act
            var result = input.GetResult(currency.rate, currency2.rate, amount);

            //Assert
            Assert.IsInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        public void GetResult_SameCurrencies_ReturnsAmount()
        {
            //Lets find out if supplied currencies match and the same provided amount is returned
            //Arrange
            var currency = new Currency("Dollar", "USD", 6.2487);
            var currency2 = new Currency("Dollar", "USD", 6.2487);
            double amount = 20;
            var input = new InputWrapper();

            //Act
            var result = input.GetResult(currency.rate, currency2.rate, amount);

            //Assert
            Assert.AreEqual(result, amount);
        }

        [TestMethod]
        public void ParseCurrPair()
        {
            //Lets test if our ParseCurrPair method is returning two correct ISO Currencies
            //Arrange
            var inputString = "EUR/DKK";
            var input = new InputWrapper();
            string[] example = { "EUR", "DKK" };

            //Act
            var result = input.ParseCurrencyPair(inputString);

            //Assert
            CollectionAssert.AreEqual(example, result);
        }
    }
}
