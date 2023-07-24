using Agency.Exceptions;

namespace Agency.ValidationHelpers
{
    public class TicketValidator
    {
        public static double ValidatePrice(double value)
        {
            if (value < 0)
            {
                throw new InvalidUserInputException($"Value of 'costs' must be a positive number. Actual value: {value:f2}.");
            }

            return value;
        }
    }
}
