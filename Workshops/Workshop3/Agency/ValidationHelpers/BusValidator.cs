using Agency.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.ValidationHelpers
{
    public class BusValidator
    {
        public static void CapacityPassanger(int currentValue, int maxValue, int minValue)
        {
            if (currentValue < minValue || currentValue > maxValue)
            {
                throw new InvalidUserInputException($"A bus cannot have less than {minValue} passengers or more than {maxValue} passengers.");
            }
        }
        public static void PricePerKilometer(double currentPrice, double maxPrice, double minPrice)
        {
            if (currentPrice < minPrice || currentPrice > maxPrice)
            {
                throw new InvalidUserInputException($"A vehicle with a price per kilometer lower than ${minPrice:f2} or higher than ${maxPrice:f2} cannot exist!");
            }
        }

    }
}
