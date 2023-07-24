using CosmeticsShop.Commands;
using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Helpers
{
    public static class CommandValidator
    {
        public static void ValidateLength(int stringToValidateLength, int minLength, int maxLength,
             string customErrorMessage)
        {
            if (stringToValidateLength < minLength || stringToValidateLength > maxLength)
            {
                throw new ArgumentException($"{customErrorMessage} " +
                    $"should be between {minLength} and {maxLength} " +
                    $"symbols.");
            }
        }

        public static void ValidateParametersCount(List<string> parameters, int expectedCount, string commandName)
        {
            if (parameters.Count != expectedCount)
            {
                throw new ArgumentException($"{commandName} command expects {expectedCount} parameters.");
            }
        }

        public static double ValidatePositive(string value, string customErrorMessage)
        {
            if (double.TryParse(value, out double number))
            {
                if (number < 0)
                {
                    throw new ArgumentException("Price can't be negative.");
                }
                else
                {
                    return number;
                }
            }
            else
            {
                throw new ArgumentException($"{customErrorMessage} parameter should be price (real number).");
            }

        }

        public static GenderType ParseGenderType(string value, string customErrorMessage)
        {
            if (Enum.TryParse(value, true, out GenderType result))
            {
                return result;
            }
            throw new ArgumentException($"{customErrorMessage} parameter should be one of Men, Women or Unisex.");
        }

        public static CommandType ParseCommandType(string value)
        {
            if (Enum.TryParse(value, true, out CommandType result))
            {
                return result;
            }
            throw new ArgumentException($"Command {value} is not supported.");
        }
    }
}
