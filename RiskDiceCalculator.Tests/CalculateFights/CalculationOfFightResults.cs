using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class CalculationOfFightResults
    {
        private readonly CalculateFights _calculateFights;  

        public CalculationOfFightResults()
        {
            _calculateFights = new CalculateFights();
        }

        [Fact]
        public void ThrowsErrorWhenAttackerArmyIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=>
            _calculateFights.CalculationOfFightResults((0, 1), [2, 1], [2,1]));

            Assert.Equal("attackerArmy", exception.ParamName);
        }
        [Fact]
        public void ThrowsErrorWhenDefenderArmyIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=>
            _calculateFights.CalculationOfFightResults((1, 0), [2,1], [2,1]));

            Assert.Equal("defenderArmy", exception.ParamName);
        }
        [Fact]
        public void ThrowsErrorWhenAttackerDiceArrayIsEmpty()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=>
            _calculateFights.CalculationOfFightResults((1, 1), [], [2, 1]));

            Assert.Equal("attackerDice", exception.ParamName);
        }
        [Fact]
        public void ThrowsErrorWhenDefenderDiceArrayIsEMpty()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _calculateFights.CalculationOfFightResults((1, 1), [2, 1], []));
        }
        [Fact]
        public void DefenderWinsWithOneDice()
        {
            (int attackerArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6, 6], [6]);
            Assert.Equal(results, (4, 5));
        }
        [Fact]
        public void DefenderLosesWithOneDice()
        {
            (int attackerArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6, 6], [5]);
            Assert.Equal(results, (5, 4));
        }
        [Fact]
        public void DefenderWinsWithOneAttackerDice()
        {
            (int attackerArym, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6], [6, 3]);
            Assert.Equal(results, (4, 5));
        }
        [Fact]
        public void DefenderLosesWithOneAttackerDice()
        {
            (int attackerArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6], [5, 3]);
            Assert.Equal(results, (5, 4));
        }
        [Fact]
        public void AttackerWinsTwoFights()
        {
            (int attackerArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6, 6, 5], [5, 5]);
            Assert.Equal(results, (5, 3));
        }
        [Fact]
        public void DefenderWinsTwoFights()
        {
            (int attackerArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5, 5), [6, 3, 3], [6, 3]);
            Assert.Equal(results, (3, 5));
        }
        [Fact]
        public void FightIsADraw()
        {
            (int attackedArmy, int defenderArmy) results = _calculateFights.CalculationOfFightResults((5,5), [6,2,1], [6,1]);
            Assert.Equal(results, (4,4));
        }

    }
}
