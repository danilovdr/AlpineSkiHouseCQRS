using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class UserAbonementModel
    {
        public Guid Id { get; set; }
        public UserModel UserId { get; set; }
        public AbonementModel AbonementId { get; set; }
        public int Cost { get; set; }
    }
}
