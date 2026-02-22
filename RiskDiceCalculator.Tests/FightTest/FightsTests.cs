using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class FightsTests
    {
        private readonly Fight _fight;

        public FightsTests()
        {
            _fight = new Fight();
        }

        [Fact]
        public void ThrowErrorWhenAttackerArmySizeIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _fight.SingleFight((0, 1)));

            Assert.Equal("attackerArmy", exception.ParamName);
        }
        [Fact]
        public void ThrowErrorWhenDefenderArmySizeIs0()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() =>
            _fight.SingleFight((1, 0)));

            Assert.Equal("defenderArmy", exception.ParamName);
        }
        [Fact]
        public void OnlyOneSoldierDiesWhenAttackerSizeis1()
        {
            (int attackerArmy, int defenderArmy) = _fight.SingleFight((1, 3));

            Assert.Equal(attackerArmy + defenderArmy, 3);
            Assert.True(attackerArmy == 0 ^ defenderArmy == 2);
        }

        [Fact]
        public void OnlyOneSoldierDiesWhenDefenderSizeIs1()
        {
            (int attackerArmy, int defenderArmy) = _fight.SingleFight((3, 1));

            Assert.Equal(attackerArmy + defenderArmy, 3);
            Assert.True(attackerArmy == 2 ^ defenderArmy ==0);
        }
        [Fact]
        public void OneOrTwoSoldiersDieWHenDefenderAndAttackerSizeIsAbove1()
        {
            (int attackerArmy, int defenderArmy) = _fight.SingleFight((3, 3));

            Assert.InRange(attackerArmy + defenderArmy, 4, 5);
            Assert.InRange(attackerArmy, 1, 3);
            Assert.InRange(defenderArmy, 1, 3);
        }
    }
}
