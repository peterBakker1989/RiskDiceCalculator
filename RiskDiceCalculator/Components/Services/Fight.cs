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
        public (int, int) FightTillDeath((int attackerArmy, int defenderArmy) armySize)
        {
            while(armySize.attackerArmy !=0 && armySize.defenderArmy !=0)
            {
                armySize = SingleFight(armySize);
            }
            return armySize;
        }
        public (int, int) SingleFight((int attackerArmy, int defenderArmy) armySize)
        {
            int attackerDice;
            int defenderDice;
            List<int> attackersThrow = new List<int>();
            List<int> defendersThrows = new List<int>();

            if (armySize.attackerArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(armySize.attackerArmy), "Aanvaller kan niet 0 legers hebben");
            }
            if (armySize.defenderArmy <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(armySize.defenderArmy), "Verdediger kan niet 0 legers hebben");
            }

           // calculate attacker dice
            attackerDice = _calculateAmountOfDice.CalculateAmountOfDiceForAttacker(armySize.attackerArmy);
            // throw for attacker
            attackersThrow = _getDiceResults.GetSortedListForAmountOfDices(attackerDice);
            //calculate defender dice
            defenderDice = _calculateAmountOfDice.CalculateAmountOfDiceForDefender(armySize.defenderArmy, attackersThrow);
            // throw for defender
            defendersThrows = _getDiceResults.GetSortedListForAmountOfDices(defenderDice);

            // calculate fightOutcome
           return _calculateFights.CalculationOfFightResults(armySize, attackersThrow, defendersThrows);
        }
    }
}
