using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private string ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
            : base(name, brand, price, gender)
        {
            if (string.IsNullOrEmpty(ingredients))
            {
                throw new ArgumentNullException("Ingredients cannot be null");
            }
            this.ingredients = ingredients;
        }
        string IToothpaste.Ingredients { get { return ingredients; } }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine +
                 $" #Ingredients: {ingredients}" + Environment.NewLine +
                 " ===";
        }
    }
}
