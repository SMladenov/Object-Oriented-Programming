
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {

        public ShowUsersCommand(IRepository repository)
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            var user = Repository.LoggedUser;
            var role = user.Role;
            if (role != Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            var users = Repository.Users;

            var str = new StringBuilder();
            str.AppendLine("--USERS--");

            for (int i = 0; i < users.Count; i++)
            {
                var currentUser = users[i];
                str.AppendLine($"{i + 1}. Username: {currentUser.Username}, FullName: {currentUser.FirstName}" +
                    $" {currentUser.LastName}, Role: {currentUser.Role}");
            }
            return str.ToString();
        }

        //ToDo
    }
}
