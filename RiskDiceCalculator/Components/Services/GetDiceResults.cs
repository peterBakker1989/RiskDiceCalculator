namespace RiskDiceCalculator.Components.Services
{
    public class GetDiceResults
    {
        public List<int> DiceRol(int amountOfDice)
        {
            if (amountOfDice <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amountOfDice),
                    "Aantal dobbelstenen moet groter dan 0 zijn."
                );
            if (amountOfDice >= 100)
                throw new ArgumentOutOfRangeException(
                    nameof(amountOfDice),
                        "Aantal dobbelstenen mag niet hoger zijn als 100"
                        );

            Random random = new Random();
            List<int> diceResults = new List<int>();
            for (int i = 0; i < amountOfDice; i++)
            {
                diceResults.Add(Random.Shared.Next(1, 7));
            }
            return diceResults;
        }

        public List<int> SortDiceroll(List<int> diceResults)
        {

            if(diceResults.Count == 0)
                throw new ArgumentOutOfRangeException(
                    nameof(diceResults),
                    "Aantal worpen kan niet leeg zijn"
                    );
            diceResults.Sort((a, b) => b.CompareTo(a));
            return diceResults;
        }

        public List<int> GetSortedListForAmountOfDices(int amountOfDices)
        {
            List<int> values = DiceRol(amountOfDices);
            return SortDiceroll(values);
        }
    }
}
