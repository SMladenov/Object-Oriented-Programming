using System;
using System.Diagnostics;
using Agency.Models.Contracts;
using Agency.ValidationHelpers;

namespace Agency.Models
{
    public class Journey : IJourney, IHasId
    {
        public const int StartLocationMinLength = 5;
        public const int StartLocationMaxLength = 25;
        public const int DestinationMinLength = 5;
        public const int DestinationMaxLength = 25;
        public const int DistanceMinValue = 5;
        public const int DistanceMaxValue = 5000;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            JourneyValidator.StartingLocationLength(from.Length, StartLocationMaxLength, StartLocationMinLength);
            JourneyValidator.DestinationLocationLength(to.Length, DestinationMaxLength, DestinationMinLength);
            JourneyValidator.Distance(distance, DistanceMaxValue, DistanceMinValue);
            Id = id;
            StartLocation = from;
            Destination = to;
            Distance = distance;
            Vehicle = vehicle;
        }

        public int Id { get; }

        public string StartLocation { get; }

        public string Destination { get; }

        public int Distance { get; }

        public IVehicle Vehicle { get; }

        public double CalculatePrice()
        {
            double travelCosts = Distance * Vehicle.PricePerKilometer;
            return travelCosts;
        }
        public string Print()
        {
            return @$"Journey ----
Start location: {StartLocation}
Destination: {Destination}
Distance: {Distance}
Travel costs: {CalculatePrice():f2}";
        }

    }
}
