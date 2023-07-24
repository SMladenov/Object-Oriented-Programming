using CosmeticsShop.Core;
using CosmeticsShop.Helpers;
using CosmeticsShop.Models;
using System;
using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class AddProductToCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public AddProductToCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            // TODO: Validate parameters count
            try
            {
                CommandValidator.ValidateParametersCount(parameters, 2, nameof(AddProductToCategory));
                string categoryName = parameters[0];
                string productName = parameters[1];
                Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);

                Product product = this.cosmeticsRepository.FindProductByName(productName);
                category.AddProduct(product);

                return $"Product {productName} added to category {categoryName}!";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
