using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Vehicle : IVehicle, IHasId
    {
        private int passangerCapacity;
        private double pricePerKilometer;
        private int id;
        public Vehicle(int passangerCapacity, double pricePerKilometer, int id)
        {
            PassangerCapacity = passangerCapacity;
            PricePerKilometer = pricePerKilometer;
            this.id = id;
        }
        public int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            set
            {
                this.passangerCapacity = value;
            }
        }
        public double PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            set
            {
                this.pricePerKilometer = value;
            }
        }

        public int Id
        {
            get { return this.id; }
        }

        public virtual string Print()
        {
            return @$"Passenger capacity: {PassangerCapacity}
Price per kilometer: {PricePerKilometer:f2}";

        }
    }
}
