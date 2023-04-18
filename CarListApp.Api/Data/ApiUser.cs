using System;
using Microsoft.AspNetCore.Identity;

namespace CarListApp.Api.Data
{
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

