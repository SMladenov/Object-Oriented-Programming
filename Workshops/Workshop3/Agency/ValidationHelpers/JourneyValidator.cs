using Agency.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.ValidationHelpers
{
    public class JourneyValidator
    {
        public static void StartingLocationLength(int startLocationLength, int maxValue, int minValue)
        {
            if (startLocationLength < minValue || startLocationLength > maxValue)
            {
                throw new InvalidUserInputException($"The length of StartLocation must be " +
                    $"between {minValue} and {maxValue} symbols.");
            }
        }
        public static void DestinationLocationLength(int destinationLocationLength, int maxValue, int minValue)
        {
            if (destinationLocationLength < minValue || destinationLocationLength > maxValue)
            {
                throw new InvalidUserInputException($"The length of Destination must be " +
                    $"between {minValue} and {maxValue} symbols.");
            }
        }

        public static void Distance(int distance, int maxValue, int minValue)
        {
            if (distance < minValue || distance > maxValue)
            {
                throw new InvalidUserInputException($"The Distance cannot be less than {minValue} or more than {maxValue} kilometers.");
            }
        }
    }
}
