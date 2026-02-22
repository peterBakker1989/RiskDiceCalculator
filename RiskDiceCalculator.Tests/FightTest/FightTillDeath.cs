using RiskDiceCalculator.Components.Services;

namespace RiskDiceCalculator.Tests
{
    public class FightTillDeath
    {
        private readonly Fight _fight;
        public FightTillDeath()
        {
            _fight = new Fight();
        }
        [Fact]
        public void FightTillDeathShouldEndWithOneArmySizeOf0()
        {
            (int attackerArmy, int defenderArmy) = _fight.FightTillDeath((10, 10));
            Assert.True(attackerArmy == 0 ^ defenderArmy == 0);
            if (attackerArmy == 0)
            {
                Assert.InRange(defenderArmy, 1, 10);
            }
            else
            {
                Assert.InRange(attackerArmy, 1, 10);
            }
        }
    }
}
