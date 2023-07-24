using Agency.Models.Contracts;
using Agency.ValidationHelpers;
using System;

namespace Agency.Models
{
    public class Train : Vehicle, ITrain
    {
        public const int PassengerCapacityMinValue = 30;
        public const int PassengerCapacityMaxValue = 150;
        public const double PricePerKilometerMinValue = 0.10;
        public const double PricePerKilometerMaxValue = 2.50;
        public const int CartsMinValue = 1;
        public const int CartsMaxValue = 15;
        private int carts;
        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts)
            : base(passengerCapacity, pricePerKilometer, id)
        {

            TrainValidator.PassangerCapacity(passengerCapacity, PassengerCapacityMaxValue, PassengerCapacityMinValue);
            TrainValidator.PricePerKilometer(pricePerKilometer, PricePerKilometerMaxValue, PricePerKilometerMinValue);
            TrainValidator.CartsMinMax(carts, CartsMaxValue, CartsMinValue);
            Carts = carts;
        }
        public int Carts
        {
            get
            {
                return this.carts;
            }
            set
            {
                this.carts = value;
            }
        }

        public override string Print()
        {
            return @$"Train ----
{base.Print()}
Carts amount: {Carts}";
        }

    }
}
