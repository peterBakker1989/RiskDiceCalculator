using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class CalculateAmountOfDiceForDefender
    {
        private readonly CalculateAmountOfDice _calculateAmountOfDice;

        public CalculateAmountOfDiceForDefender()
        {
            _calculateAmountOfDice = new CalculateAmountOfDice();
        }

        [Fact]
        public void ThrowsErrorWhenAmountOfTroopsIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=>
            _calculateAmountOfDice.CalculateAmountOfDiceForDefender(0, [1,2]));

            Assert.Equal("amountOfTroops", exception.ParamName);
        }
        [Fact]
        public void ThrowsErrorWhenAmountOfDicesIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _calculateAmountOfDice.CalculateAmountOfDiceForDefender(1, []));

            Assert.Equal("attackThrow", exception.ParamName);
        }
        [Fact]
        public void ThrowsErrorWhenAmountOfAttackDicesIs4()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=>
            _calculateAmountOfDice.CalculateAmountOfDiceForDefender(1, [1,2,3,4]));

            Assert.Equal("attackThrow", exception.ParamName);
        }
        [Fact]
        public void OneDiceWhenTheDefenderHasOnlyOneSolder()
        {
            Assert.Equal(1, _calculateAmountOfDice.CalculateAmountOfDiceForDefender(1, [1,1]));
        }
        [Fact]
        public void TwoDiceWhenTheAttackerHas1Dice()
        {
            Assert.Equal(2, _calculateAmountOfDice.CalculateAmountOfDiceForDefender(2, [6]));
        }
        [Fact]
        public void TwoDiceWhenTheSecondNumberIs3()
        {
            Assert.Equal(2, _calculateAmountOfDice.CalculateAmountOfDiceForDefender(2, [6,3]));
        }
        [Fact]
        public void OneDiceWhenThereAreEnoughTroopsButTheAttackerThrowsAbove3()
        {
            Assert.Equal(1, _calculateAmountOfDice.CalculateAmountOfDiceForDefender(4, [5, 5]));
        }
        [Fact]
        public void OndeDiceWhenTheSecondDiceIs4ButTheThirdIs1()
        {
            Assert.Equal(1, _calculateAmountOfDice.CalculateAmountOfDiceForDefender(5, [5,4,3]));
        }
    }
}
