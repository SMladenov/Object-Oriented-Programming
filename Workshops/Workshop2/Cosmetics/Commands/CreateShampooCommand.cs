using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 6;
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
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

            ValidationHelper.ValidateMillilitres(this.CommandParameters[4]);
            int millilitres = int.Parse(this.CommandParameters[4]);

            UsageType usage = ParseUsageType(this.CommandParameters[5]);

            return CreateShampoo(name, brand, price, gender, millilitres, usage);
        }

        private string CreateShampoo(string name, string brand, decimal price, GenderType gender,
            int millilitres, UsageType usage)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException($"Shampoo with name {name} already exists");
            }
            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);
            return $"Shampoo with name {name} was created!";
        }
    }
}
