using AlpineSkiHouseCQRS.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Commands
{
    public class RegistrationCommand : ICommand
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
