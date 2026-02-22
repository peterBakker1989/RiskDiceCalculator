namespace RiskDiceCalculator.Components.Services
{
    public class CalculateFights
    {

        public (int, int) CalculationOfFightResults(int attackerArmy, int defenderArmy, List<int> attackerDice, List<int> defenderDice)
        {
            if(attackerArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(attackerArmy), "Aanvaller kan niet 0 legers hebben");
            }
            if(defenderArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(defenderArmy), "Verdediger kan niet 0 legers hebben");
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
                if (attackerDice[0] > defenderDice[0]) { defenderArmy--; }
                else { attackerArmy--; }

                if (attackerDice.Count >= 2 && defenderDice.Count >= 2)
                {
                    if (attackerDice[1] > defenderDice[1]) { defenderArmy--; }
                    else { attackerArmy--; }
                }
            }
            return (attackerArmy, defenderArmy);
        }

    }
}
