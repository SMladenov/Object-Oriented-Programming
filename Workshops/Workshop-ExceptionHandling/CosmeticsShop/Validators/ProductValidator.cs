using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticsShop.Validators
{
    public static class ProductValidator
    {
        public static void ValidateProductUnique(List<Product> products, string productName)
        {
            if (products.Select(x => x.Name).Contains(productName, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Product {productName} already exist.");
            }
        }

        public static void ValidateProductExists(List<Product> products, string productName)
        {
            if (!products.Select(x => x.Name).Contains(productName, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Product {productName} does not exist.");
            }
        }
    }
}
