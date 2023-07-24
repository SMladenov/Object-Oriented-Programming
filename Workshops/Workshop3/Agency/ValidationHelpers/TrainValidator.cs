using Agency.Exceptions;
using System;

namespace Agency.ValidationHelpers
{
    public class TrainValidator
    {
        public static void PassangerCapacity(int currentValue, int maxValue, int minValue)
        {
            if (currentValue < minValue || currentValue > maxValue)
            {
                throw new InvalidUserInputException($"A train cannot have less than {minValue} passengers or more than {maxValue} passengers.");
            }
        }

        public static void PricePerKilometer(double currentPrice, double maxPrice, double minPrice)
        {

            if (currentPrice < minPrice || currentPrice > maxPrice)
            {
                throw new InvalidUserInputException($"A vehicle with a price per kilometer lower than ${minPrice:f2} or higher than ${maxPrice:f2} cannot exist!");
            }
        }

        public static void CartsMinMax(int cartsCurrentValue, int maxValue, int minValue)
        {
            if (cartsCurrentValue < minValue || cartsCurrentValue > maxValue)
            {
                throw new InvalidUserInputException($"A train cannot have less than {minValue} cart or more than {maxValue} carts.");
            }
        }
    }
}
