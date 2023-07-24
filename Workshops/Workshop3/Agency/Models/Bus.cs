using Agency.Models.Contracts;
using Agency.ValidationHelpers;
using System;

namespace Agency.Models
{
    public class Bus : Vehicle, IBus
    {
        public const int PassengerCapacityMinValue = 10;
        public const int PassengerCapacityMaxValue = 50;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;

        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv)
            : base(passengerCapacity, pricePerKilometer, id)
        {
                BusValidator.CapacityPassanger(passengerCapacity, PassengerCapacityMaxValue, PassengerCapacityMinValue);
                BusValidator.PricePerKilometer(pricePerKilometer, PricePerKilometerMaxValue, PricePerKilometerMinValue);
                HasFreeTv = hasFreeTv;
        }
        public bool HasFreeTv { get; }

        public override string Print()
        {
            return @$"Bus ----
{base.Print()}
Has free TV: {HasFreeTv}";
        }
    }
}
