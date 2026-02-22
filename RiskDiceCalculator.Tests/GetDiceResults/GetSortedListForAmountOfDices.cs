using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class GetSortedListForAmountOfDices
    {
        private readonly GetDiceResults _getDiceResults;

        public GetSortedListForAmountOfDices()
        {
            _getDiceResults = new GetDiceResults();
        }

        [Fact]
        public void GetCorrectAmount()
        {
            List<int> results = _getDiceResults.GetSortedListForAmountOfDices(8);
            // list should have the same 
            Assert.Equal(8, results.Count);
        }

        [Fact]
        public void GetSorrtedResult()
        {
            List<int> results = _getDiceResults.GetSortedListForAmountOfDices(60);
            // list should have the same length
            Assert.Equal(60, results.Count);
            // list should be sorted
            for (int i = 0; i < results.Count - 1; i++)
            {
                Assert.True(results[i] >= results[i + 1]);
            }
        }
        [Fact]
        public void AnErrorIsThrownWhenSendingIn0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 
            _getDiceResults.GetSortedListForAmountOfDices(0));

            Assert.Equal("amountOfDice", exception.ParamName);
        }

    }
}
