using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 15;
        public const int BrandMinLength = 3;
        public const int BrandMaxLength = 15;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            string name = this.CommandParameters[0];
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);

            string brand = this.CommandParameters[1];
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);

            ValidationHelper.ValidatePrice(this.CommandParameters[2]);
            decimal price = decimal.Parse(this.CommandParameters[2]);

            GenderType gender = ParseGenderType(this.CommandParameters[3]);

            ScentType scent = ParseScentType(this.CommandParameters[4]);

            return CreateCream(name, brand, price, gender, scent);
        }

        private string CreateCream(string name, string brand, decimal price, GenderType gender,
        ScentType scent)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Shampoo with name {name} already exists");
            }
            this.Repository.CreateCream(name, brand, price, gender, scent);
            return $"Cream with name {name} was created!";
        }
    }
}
