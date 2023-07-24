using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Product : IProduct
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;
        private readonly GenderType gender;
        private string name;
        private string brand;
        private decimal price;
        //May be abstract
        public Product(string name, string brand, decimal price, GenderType gender)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);
            ValidationHelper.ValidateNonNegative(price, "The price cannot be negative");
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.gender = gender;
        }
        string IProduct.Name { get => name; }

        string IProduct.Brand { get => brand; }

        decimal IProduct.Price { get => price; }
        GenderType IProduct.Gender { get => gender; }

        public override string ToString()
        {
            return $" #{name} {brand}" + Environment.NewLine +
              $" #Price: ${price}" + Environment.NewLine +
              $" #Gender: {gender}";
        }

        string IProduct.Print()
        {
            return this.ToString();
        }
    }
}
