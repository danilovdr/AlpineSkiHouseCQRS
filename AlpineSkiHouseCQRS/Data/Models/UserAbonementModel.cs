using System;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class UserAbonementModel
    {
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid AbonementId { get; set; }
        public AbonementModel Abonement { get; set; }

        public int Cost { get; set; }
    }
}
