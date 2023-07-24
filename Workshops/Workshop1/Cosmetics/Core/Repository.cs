using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private readonly List<Product> products;
        private readonly List<Category> categories;
        private readonly ShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<Product>();
            this.categories = new List<Category>();

            this.shoppingCart = new ShoppingCart();
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>(this.categories);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public Product FindProductByName(string productName)
        {
            //var prod = this.products
            //    .FirstOrDefault(x => x.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));


            foreach (var item in products)
            {
                if (productName == item.Name)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Product {productName} does not exist");
            /**
             * Hint: You have to go through every product and see if one has name equal to productName.
             *       If not, "throw new ArgumentException("Product {productName} does not exist");"
             */
            //throw new NotImplementedException("Not implemented yet.");
        }

        public Category FindCategoryByName(string categoryName)
        {
            foreach (var item in categories)
            {
                if (categoryName == item.Name)
                {
                    return item;
                }
            }
            throw new ArgumentException($"Category {categoryName} does not exist");
            /**
             * Hint: You have to go through every category and see if one has name equal to categoryName.
             *       If not, "throw new ArgumentException("Category {categoryName} does not exist");"
             */
            //throw new NotImplementedException("Not implemented yet.");
        }

        public void CreateCategory(string categoryName)
        {
            Category category = new Category(categoryName);
            this.categories.Add(category);
            //throw new NotImplementedException("Not implemented yet.");
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            Product product = new Product(name, brand, price, gender);
            this.products.Add(product);
            //throw new NotImplementedException("Not implemented yet.");
        }

        public bool CategoryExist(string categoryName)
        //=> this.categories.Any(c => c.Name.Equals(categoryName));
        {
            foreach (var item in categories)
            {
                if (categoryName == item.Name)
                {
                    return true;
                }
            }
            return false;
            /**
             * Hint: You have to go through each category and see if one has name equal to categoryName.
             *       If there is one, return true. If not, return false.
             */
            //throw new NotImplementedException("Not implemented yet.");
        }

        public bool ProductExist(string productName)
        {
            foreach (var item in products)
            {
                if (productName == item.Name)
                {
                    return true;
                }
            }
            return false;
            /**
             * Hint: You have to go through each product and see if one has name equal to productName.
             *       If there is one, return true. If not, return false.
             */
            //throw new NotImplementedException("Not implemented yet.");
        }
    }
}
