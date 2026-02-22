using RiskDiceCalculator.Components.Services;


namespace RiskDiceCalculator.Tests
{
    public class DiceCalculatorTests
    {
        private readonly GetDiceResults _results;

        public DiceCalculatorTests()
        {

            _results = new GetDiceResults();
        }
        [Fact]
        public void AmountOfDiceShouldBeEqualToTheAmountRequested()
        {
            // throwDice
            List<int> results = _results.DiceRol(3);
            // amount of dice should be equal
            Assert.Equal(3, results.Count);
            Assert.All(results, n => Assert.InRange(n, 1, 6));
        }
        [Fact]
        public void AmountOfDiceShouldBeBetween1And6()
        {
            // throwDice
            List<int> results = _results.DiceRol(99);
            // amount of dice should be between 1 and 6
            Assert.All(results, n => Assert.InRange(n, 1, 6));
        }
        [Fact]
        public void AmountOfDiceCanNotBe0()
        {
            // error if amount is 0
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _results.DiceRol(0)
                );

            Assert.Equal("amountOfDice", exception.ParamName);
        }
        [Fact]
        public void AmountOfDiceCanNotBe0ver100()
        {
            // error if amount is 100
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _results.DiceRol(100)
            );

            Assert.Equal("amountOfDice", exception.ParamName);
        }
    }
}