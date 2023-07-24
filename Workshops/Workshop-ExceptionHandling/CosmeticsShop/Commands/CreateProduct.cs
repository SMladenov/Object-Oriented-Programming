using CosmeticsShop.Core;
using CosmeticsShop.Helpers;
using CosmeticsShop.Models;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace CosmeticsShop.Commands
{
    public class CreateProduct : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateProduct(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            // TODO: Validate parameters count

            try
            {
                CommandValidator.ValidateParametersCount(parameters, 4, nameof(CreateProduct));
                string name = parameters[0];
                CommandValidator.ValidateLength(name.Length, 3, 10, "Product name");
                string brand = parameters[1];
                CommandValidator.ValidateLength(brand.Length, 2, 10, "Product brand");
                double price = CommandValidator.ValidatePositive(parameters[2], "Third");
                GenderType gender = CommandValidator.ParseGenderType(parameters[3], "Forth");

                this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

                return $"Product with name {name} was created!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }


            // TODO: Validate price format


            // TODO: Validate gender format


            // TODO: Ensure category name is unique
        }
    }
}
