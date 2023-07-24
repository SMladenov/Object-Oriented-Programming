using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 5;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
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
            string ingredients = this.CommandParameters[4];

            return CreateToothpaste(name, brand, price, gender, ingredients);
        }

        private string CreateToothpaste(string name, string brand, decimal price, GenderType gender,
             string ingredients)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Toothpaste with name {name} already exists");
            }
            this.Repository.CreateToothpaste(name, brand, price, gender, ingredients);
            return $"Toothpaste with name {name} was created!";
        }
    }
}
