using AlpineSkiHouseCQRS.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Commands
{
    public class AuthorizationCommand : ICommand
    {
        [Required(ErrorMessage = "Email is empty")]
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is empty")]
        [DataType(DataType.Password)]
        [StringLength(25, MinimumLength = 5, ErrorMessage =" Password must be from 5 to 25 characters")]
        public string Password { get; set; }
    }
}
