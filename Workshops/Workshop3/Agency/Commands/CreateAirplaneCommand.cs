using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateAirplaneCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            int passengerCapacity = this.ParseIntParameter(base.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = this.ParseDoubleParameter(base.CommandParameters[1], "pricePerKilometer");
            bool isLowCost = base.ParseBoolParameter(base.CommandParameters[2], "isLowCost");

            var airplane = base.Repository.CreateAirplane(passengerCapacity, pricePerKilometer, isLowCost);
            return $"Vehicle with ID {airplane.Id} was created.";
        }
    }
}
