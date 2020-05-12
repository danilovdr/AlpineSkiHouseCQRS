using AlpineSkiHouseCQRS.Domain;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class UserModel : User
    {
        [MaxLength(64)]
        public byte[] Password { get; set; }
        [MaxLength(64)]
        public byte[] Salt { get; set; }
        public IdentityRole<string> Role { get; set; }

        public List<UserAbonementModel> UserAbonement { get; set; }
    }
}
