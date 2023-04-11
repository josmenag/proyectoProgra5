using System;
using System.ComponentModel.DataAnnotations;

namespace CarListApp.Api.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your password is lmited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

