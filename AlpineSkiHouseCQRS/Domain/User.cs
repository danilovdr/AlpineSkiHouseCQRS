using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineSkiHouseCQRS.Domain
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
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

        [NotMapped]
        public string FullName => $"{MiddleName} {FirstName} {SecondName}";
    }
}
