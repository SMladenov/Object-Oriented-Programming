using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            this.products = new List<Product>();
            //products = new List<Product>();
            //throw new NotImplementedException("Not implemented yet.");
        }

        public List<Product> Products
        {
            get
            {
                //If somebody from outside wants to see what product do we have in the Cart, we provide a copy of the List
                //return new List<Product>(products);
                return this.products.ToList();
                // List encapsulation is tricky.
                //throw new NotImplementedException("Not implemented yet.");
            }
        }

        public void AddProduct(Product product)
        {
            //N.B.! We work with the collection from down which is "products"
            products.Add(product);
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

        public bool ContainsProduct(Product product)
        {
            if (products.Contains(product))
            {
                return true;
            }
            return false;
            //throw new NotImplementedException("Not implemented yet.");
        }

        public double TotalPrice()
        {
            //var sum = products.Sum(x => x.Price);


            double total = 0;
            foreach (var product in products)
            {
                double tempPrice = product.Price;
                total += tempPrice;
            }
            return total;
            //throw new NotImplementedException("Not implemented yet.");
        }
    }
}
