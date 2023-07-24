using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private int millilitres;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            : base(name, brand, price, gender)
        {
            ValidationHelper.ValidateNonNegative(millilitres, "Millilitres cannot be negative");
            this.millilitres = millilitres;
            this.usage = usage;
        }
        int IShampoo.Millilitres { get { return millilitres; } }
        UsageType IShampoo.Usage { get { return usage; } }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                 $" #Milliliters: {millilitres}" + Environment.NewLine +
                 $" #Usage: {usage}" + Environment.NewLine +
                 " ===";
        }
    }
}
