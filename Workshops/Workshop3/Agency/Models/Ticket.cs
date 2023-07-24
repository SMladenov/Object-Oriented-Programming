using System;
using System.Security.Cryptography.X509Certificates;
using Agency.Models.Contracts;
using Agency.ValidationHelpers;

namespace Agency.Models
{
    public class Ticket : ITicket, IHasId
    {
        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            Id = id;
            Journey = journey;
            AdministrativeCosts = TicketValidator.ValidatePrice(administrativeCosts);
        }

        public int Id { get; }

        public IJourney Journey { get; }

        public double AdministrativeCosts { get; }

        public double CalculatePrice()
        {
            double totalPrice = AdministrativeCosts * Journey.CalculatePrice();
            return totalPrice;
        }

        public string Print()
        {
            return @$"Ticket ----
Destination: {Journey.Destination}
Price: {CalculatePrice():f2}";
        }
    }
}
