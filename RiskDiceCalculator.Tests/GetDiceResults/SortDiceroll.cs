using Microsoft.VisualStudio.TestPlatform.Utilities;
using RiskDiceCalculator.Components.Services;
using Xunit.Abstractions;

namespace RiskDiceCalculator.Tests
{
    public class SortDiceroll
    {
        private readonly GetDiceResults _results;
        private readonly ITestOutputHelper _output;

        public SortDiceroll(ITestOutputHelper  output)
        {

            _results = new GetDiceResults();
            _output = output;
        }
        [Fact]
        public void ArrayReturnsInputSorted()
        {
            List<int> inputs = new List<int>() { 6,5,3,4,2,1};  
            // throwDice
            List<int> results = _results.SortDiceroll(inputs);
            // amount of dice should be equal
            Assert.Equal(6, results.Count);
            for (int i = 0; i < inputs.Count - 1; i++)
            {
                Assert.True(inputs[i] >= inputs[i + 1]);
                _output.WriteLine(inputs[i].ToString());
            }
        }
    }
}
