namespace RiskDiceCalculator.Components.Services
{
    public class Fight
    {
        private readonly CalculateAmountOfDice _calculateAmountOfDice;
        private readonly CalculateFights _calculateFights;
        private readonly GetDiceResults _getDiceResults;

        public Fight()
        {
            _calculateAmountOfDice = new CalculateAmountOfDice();
            _calculateFights = new CalculateFights();
            _getDiceResults = new GetDiceResults();
        }
        public (int, int) Fights(int attackerArmy, int defenderArmy)
        {
            int attackerDice;
            int defenderDice;
            List<int> attackersThrow = new List<int>();
            List<int> defendersThrows = new List<int>();

            if (attackerArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(attackerArmy), "Aanvaller kan niet 0 legers hebben");
            }
            if (defenderArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(defenderArmy), "Verdediger kan niet 0 legers hebben");
            }

           // calculate attacker dice
            attackerDice = _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(attackerArmy);
            // throw for attacker
            attackersThrow = _getDiceResults.GetSortedListForAmountOfDices(attackerDice);
            //calculate defender dice
            defenderDice = _calculateAmountOfDice.CalculateAmountOfDiceForDefender(defenderArmy, attackersThrow);
            // throw for defender
            defendersThrows = _getDiceResults.GetSortedListForAmountOfDices(defenderDice);

            // calculate fightOutcome
           return _calculateFights.CalculationOfFightResults(attackerArmy, defenderArmy, attackersThrow, defendersThrows);
        }
    }
}
