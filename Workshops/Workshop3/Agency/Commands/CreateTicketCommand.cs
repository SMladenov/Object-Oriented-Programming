using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using Agency.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Agency.Commands
{
    public class CreateTicketCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateTicketCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            var journeyId = this.CommandParameters[0];
            var journeyIdNumber = base.ParseIntParameter(journeyId, nameof(journeyId));
            var administrativeCosts = this.CommandParameters[1];
            var costs = base.ParseDoubleParameter(this.CommandParameters[1], nameof(administrativeCosts));

            var journey = base.Repository.FindJourneyById(journeyIdNumber);

           

            var ticket = base.Repository.CreateTicket(journey, costs);
            return $"Ticket with ID {ticket.Id} was created.";

        }
    }
}
