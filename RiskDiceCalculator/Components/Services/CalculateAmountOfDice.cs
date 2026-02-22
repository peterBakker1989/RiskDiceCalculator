namespace RiskDiceCalculator.Components.Services
{
    public class CalculateAmountOfDice
    {
        public int CalculateAmountOfDiceForAttacker(int amountOfTroops)
        {
            if (amountOfTroops <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amountOfTroops), "Aanvaller heeft al verloren");
            }

            // return maximaal 3 troepen
            return Math.Min(amountOfTroops, 3);
        }

        public int CalculateAmountOfDiceForDefender(int amountOfTroops, List<int> attackThrow)
        {
            if (amountOfTroops <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(amountOfTroops), "Verdediger heeft al verloren");
            }
            if (attackThrow.Count <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(attackThrow), "Aanvaller kan niet 0 dobbelstennen hebben");
            }
            if (attackThrow.Count > 3)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(attackThrow), "Aanvaller kan niet meer als 3 dobbelstennen hebben");
            }
            // als je een soldaat hebt altijd 1 terug geven
            if (amountOfTroops == 1)
            {
                return 1;
            }
            // als de tegenstander 1 soldaat heeft altijd met 2 gooien 
            if (attackThrow.Count == 1)
            {
                return 2;
            }

            int lowestThrow = attackThrow.Count > 1 ? attackThrow[1] : 0;
            if (lowestThrow <= 3)
                return 2;
            else
                return 1;


        }

       

    }
}
