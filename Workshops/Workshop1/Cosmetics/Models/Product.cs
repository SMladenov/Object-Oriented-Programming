using System;

namespace Cosmetics.Models;

public class Product
{
    public const int NameMinLength = 3;
    public const int NameMaxLength = 10;
    public const int BrandMinLength = 2;
    public const int BrandMaxLength = 10;
    private readonly GenderType gender;
    private string name;
    private string brand;
    private double price;
    // "Each product in the system has name, brand, price and gender."

    //private const string NameErrorMessage = "";

    public Product(string name, string brand, double price, GenderType gender)
    {
        Name = name;
        Brand = brand;
        Price = price;
        this.gender = gender;
        //throw new NotImplementedException("Not implemented yet.");
    }

    public double Price
    {
        get
        {
            return this.price;
            //throw new NotImplementedException("Not implemented yet.");
        }
        set
        {
            //We may use ValidationHelpers New Method

            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            this.price = value;
            //throw new NotImplementedException("Not implemented yet.");

        }
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
            //We may reuse the same format for the Brand as well
            //string errorMessage = string.Format(NameErrorMessage, NameMinLength, NameMaxLength);
            //ValidationHelpers.ValidateStringLength(value, NameMinLength, NameMaxLength, errorMessage);


            if (value.Length < NameMinLength || value.Length > NameMaxLength)
            {
                throw new ArgumentException("The Name cannot be less than 3 and more than 10");
            }
            this.name = value;
            //throw new NotImplementedException("Not implemented yet.");
        }
    }

    public string Brand
    {
        get
        {
            return this.brand;
            //throw new NotImplementedException("Not implemented yet.");
        }
        set
        {
            if (value.Length < BrandMinLength || value.Length > BrandMaxLength)
            {
                throw new ArgumentException("The Brand cannot be less than 3 and more than 10");
            }
            this.brand = value;
            //throw new NotImplementedException("Not implemented yet.");
        }
    }

    public GenderType Gender
    {
        get
        {
            return this.gender;
            //throw new NotImplementedException("Not implemented yet.");
        }
        //Or we can try to use private set


    }

    public string Print()
    {
        // Format:
        // #[Name] [Brand]
        // #Price: [Price]
        // #Gender: [Gender]
        //throw new NotImplementedException("Not implemented yet.");

        //StringBuilder result = new StringBuilder();
        //result.AppendLine($" #{Name} {Brand}");
        //result.AppendLine($"{Price:f2}");
        //result.AppendLine($"#Gender: {Gender}");
        //return result.ToString();

        return $" #{Name} {Brand}" + Environment.NewLine +
               $" #Price: ${Price}" + Environment.NewLine +
               $" #Gender: {Gender}";
    }

    public override bool Equals(object p)
    {
        if (p == null || !(p is Product))
        {
            return false;
        }

        if (this == p)
        {
            return true;
        }

        Product otherProduct = (Product)p;

        return this.Price == otherProduct.Price
                && this.Name == otherProduct.Name
                && this.Brand == otherProduct.Brand
                && this.Gender == otherProduct.Gender;
    }
}