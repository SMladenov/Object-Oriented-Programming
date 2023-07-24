
using Dealership.Core;
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameError = "name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private readonly Role role;
        private readonly IList<IVehicle> vehicles = new List<IVehicle>();
        public User(string username, string firstName, string lastName, string password, Role role)
        {

            Validator.ValidateIntRange(username.Length, NameMinLength, NameMaxLength, InvalidUsernameLengthError);
            Validator.ValidateSymbols(username, UsernamePattern, InvalidUsernameFormatError);
            Validator.ValidateIntRange(firstName.Length, NameMinLength, NameMaxLength, InvalidNameError);
            Validator.ValidateIntRange(lastName.Length, NameMinLength, NameMaxLength, InvalidNameError);
            Validator.ValidateIntRange(password.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
            Validator.ValidateSymbols(password, PasswordPattern, InvalidPasswordFormatError);

            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            this.role = role;
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public Role Role { get { return this.role; } }

        public IList<IVehicle> Vehicles
        {
            get { return this.vehicles.ToList(); }
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (role == Role.Normal)
            {
                Validator.ValidateMaxVehiclesIfNormalUser(vehicles.Count, MaxVehiclesToAdd, string.Format(NotAnVipUserVehiclesAdd, MaxVehiclesToAdd));
            }
            if (role == Role.Admin)
            {
                throw new ArgumentException(AdminCannotAddVehicles);
            }
            vehicles.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                vehicleToRemoveComment.RemoveComment(commentToRemove);
            }
            else
            {
                throw new ArgumentException(YouAreNotTheAuthor);
            }
        }

        public string PrintVehicles()
        {

            var str = new StringBuilder();
            str.AppendLine($"--USER: {username}--");

            for (int i = 0; i < vehicles.Count; i++)
            {
                var currentVehicle = vehicles[i];
                str.AppendLine($"{i + 1}. {currentVehicle.Print()}");
                var comments = currentVehicle.Comments;
                if (comments.Count > 0)
                {
                    str.AppendLine($"--COMMENTS--");
                    str.AppendLine(new string('-', 10));
                    for (int r = 0; r < comments.Count; r++)
                    {
                        if (r > 0)
                        {
                            str.AppendLine(new string('-', 10));
                            str.AppendLine(new string('-', 10));
                            str.AppendLine($"{comments[r].Content}");
                            str.AppendLine($"user: {comments[r].Author}");
                        }
                        else
                        {
                            str.AppendLine($"{comments[r].Content}");
                            str.AppendLine($"user: {comments[r].Author}");
                        }
                    }
                    str.AppendLine(new string('-', 10));
                    str.AppendLine($"--COMMENTS--");
                }
                else
                {
                    str.AppendLine($"--NO COMMENTS--");
                }
            }
            return str.ToString();
        }

        //ToDo
    }
}
