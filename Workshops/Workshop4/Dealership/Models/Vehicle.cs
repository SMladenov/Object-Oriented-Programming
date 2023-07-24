using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string make;
        private string model;
        private int wheels;
        private readonly VehicleType type;
        private decimal price;
        private readonly IList<IComment> comments = new List<IComment>();
        public Vehicle(string make, string model, int wheels, VehicleType type, decimal price)
        {
            Make = make;
            Model = model;
            Wheels = wheels;
            this.type = type;
            Price = price;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int Wheels
        {
            get { return this.wheels; }
            set { this.wheels = value; }
        }

        public VehicleType Type { get { return this.type; } }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public IList<IComment> Comments
        {
            get { return this.comments.ToList(); }
        }

        public void AddComment(IComment comment)
        {
            comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            comments.Remove(comment);
        }

        public virtual string Print()
        {
            return @$"Make: {Make}
Model: {Model}
Wheels: {Wheels}
Price: {Price}";

        }
    }
}
