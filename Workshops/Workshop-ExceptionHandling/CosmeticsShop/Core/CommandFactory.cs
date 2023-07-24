using CosmeticsShop.Commands;
using CosmeticsShop.Helpers;
using System;

namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            // TODO: Validate command format
            CommandType commandType = CommandValidator.ParseCommandType(commandTypeValue);

            switch (commandType)
            {
                case CommandType.CreateCategory:
                    return new CreateCategory(productRepository);
                case CommandType.CreateProduct:
                    return new CreateProduct(productRepository);
                case CommandType.AddProductToCategory:
                    return new AddProductToCategory(productRepository);
                case CommandType.ShowCategory:
                    return new ShowCategory(productRepository);
                default:
                    throw new ArgumentException($"Command {commandTypeValue} is not supported.");
            }
        }
    }
}
