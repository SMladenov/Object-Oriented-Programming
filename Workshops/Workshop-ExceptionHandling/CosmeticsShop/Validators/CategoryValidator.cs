using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmeticsShop.Helpers
{
    public static class CategoryValidator
    {

        public static void ValidateCategoryUnique(List<Category> category, string categoryName)
        {
            if (category.Select(x => x.Name).Contains(categoryName, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Category {categoryName} already exist.");
            }
        }

        public static void ValidateCategoryExists(List<Category> category, string categoryName)
        {
            if (!category.Select(x => x.Name).Contains(categoryName, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"Category {categoryName} does not exist.");
            }
        }

    }
}
