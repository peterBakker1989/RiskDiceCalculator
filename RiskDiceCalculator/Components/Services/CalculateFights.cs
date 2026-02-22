namespace RiskDiceCalculator.Components.Services
{
    public class CalculateFights
    {

        public (int, int) CalculationOfFightResults((int attackerArmy, int defenderArmy) armySize, List<int> attackerDice, List<int> defenderDice)
        {
            if(armySize.attackerArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(armySize.attackerArmy), "Aanvaller kan niet 0 legers hebben");
            }
            if(armySize.defenderArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(armySize.defenderArmy), "Verdediger kan niet 0 legers hebben");
            }
            if (attackerDice.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(
                nameof(attackerDice), "Aanvaller kan niet 0 dobbelstenen hebben");
            }
            if (defenderDice.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(defenderDice), "Verdediger kan niet 0 dobbelstenen hebben");
            }
            if (attackerDice.Count >= 1 && defenderDice.Count >= 1)
            {
                if (attackerDice[0] > defenderDice[0]) { armySize.defenderArmy--; }
                else { armySize.attackerArmy--; }

                if (attackerDice.Count >= 2 && defenderDice.Count >= 2)
                {
                    if (attackerDice[1] > defenderDice[1]) { armySize.defenderArmy--; }
                    else { armySize.attackerArmy--; }
                }
            }
            return (armySize.attackerArmy, armySize.defenderArmy);
        }

    }
}
