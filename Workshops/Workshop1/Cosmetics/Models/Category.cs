using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;
        private readonly List<Product> products;
        private string name;


        public Category(string name)
        {
            Name = name;
            products = new List<Product>();
            //throw new NotImplementedException("Not implemented yet.");
        }

        public string Name
        {
            get
            {
                return this.name;
                //throw new NotImplementedException("Not implemented yet.");
            }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException("The Name is outside the criteria for length");
                }
                this.name = value;
                //throw new NotImplementedException("Not implemented yet.");
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
                // List encapsulation is tricky.
                //throw new NotImplementedException("Not implemented yet.");
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
            //throw new NotImplementedException("Not implemented yet.");
        }

        public void RemoveProduct(Product product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
            }
            else
            {
                throw new ArgumentException("The product is not in the chart.");
            }
            //throw new NotImplementedException("Not implemented yet.");
        }

        public string Print()
        {
            if (products.Count == 0)
            {
                return $"#Category: {Name}" + Environment.NewLine +
                        " #No products in this category";
            }

            var result = string.Empty;
            foreach (var item in products)
            {
                result += item.Print() + Environment.NewLine +  " ===";
            }



            return $"#Category: {Name}" + Environment.NewLine + result;





            //throw new NotImplementedException("Not implemented yet.");
        }
    }
}

