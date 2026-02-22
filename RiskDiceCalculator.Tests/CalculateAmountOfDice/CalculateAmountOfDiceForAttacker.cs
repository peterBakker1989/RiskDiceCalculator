using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class CalculateAmountOfDiceForAttacker
    {
        private readonly CalculateAmountOfDice _calculateAmountOfDice;

        public CalculateAmountOfDiceForAttacker()
        {
            _calculateAmountOfDice = new CalculateAmountOfDice();
        }

        [Fact]

        public void CalculateAmountOfDiceFor0Soldiers()
        {
            // Error bij 0
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
               _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(0)
               );

            Assert.Equal("amountOfTroops", exception.ParamName);
        }
        [Fact]
        public void CalculateAMountFor1Soldiers()
        {
            Assert.Equal(1, _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(1));
        }
        [Fact]
        public void CalculateAMountFor2Soldiers()
        {
            Assert.Equal(2, _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(2));
        }
        [Fact]
        public void CalculateAMountFor3Soldiers()
        {
            Assert.Equal(3, _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(3));
        }
        [Fact]
        public void CalculateAMountFor4Soldiers()
        {
            Assert.Equal(3, _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(4));
        }
    }
}
