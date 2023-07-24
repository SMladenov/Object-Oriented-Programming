using Agency.Models.Contracts;
using Agency.ValidationHelpers;
using System;

namespace Agency.Models
{
    public class Airplane : Vehicle, IAirplane
    {
        public const int PassengerCapacityMinValue = 1;
        public const int PassengerCapacityMaxValue = 800;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;

        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost)
            : base(passengerCapacity, pricePerKilometer, id)
        {
            AirplaneValidator.CapacityPassanger(passengerCapacity, PassengerCapacityMaxValue, PassengerCapacityMinValue);
            AirplaneValidator.PricePerKilometer(pricePerKilometer, PricePerKilometerMaxValue, PricePerKilometerMinValue);
            IsLowCost = isLowCost;
        }

        public bool IsLowCost { get; }

        public override string Print()
        {
            return @$"Airplane ----
{base.Print()}
Is low-cost: {IsLowCost}";
        }
    }
}
