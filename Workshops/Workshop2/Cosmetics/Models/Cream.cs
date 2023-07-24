using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        public const int CreamNameBrandMinLength = 3;
        public const int CreamNameBrandMaxLength = 15;

        private readonly ScentType scent;
        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent)
            : base(name, brand, price, gender)
        {
            ValidationHelper.ValidateStringLength(name, CreamNameBrandMinLength, CreamNameBrandMaxLength);
            ValidationHelper.ValidateStringLength(brand, CreamNameBrandMinLength, CreamNameBrandMaxLength);
            this.scent = scent;
        }

        public ScentType ScentType { get => scent; }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                 $" #ScentType: {ScentType}" + Environment.NewLine +
                 " ===";
        }

    }
}
