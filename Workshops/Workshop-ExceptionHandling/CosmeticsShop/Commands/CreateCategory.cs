using CosmeticsShop.Core;
using CosmeticsShop.Helpers;
using System;
using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            // TODO: Validate parameters count

            try
            {
                CommandValidator.ValidateParametersCount(parameters, 1, nameof(CreateCategory));
                string categoryName = parameters[0];
                CommandValidator.ValidateLength(categoryName.Length, 3, 10, "Category name");
                this.cosmeticsRepository.CreateCategory(categoryName);
                return $"Category with name {categoryName} was created!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            // TODO: Ensure category name is unique
        }
    }
}
