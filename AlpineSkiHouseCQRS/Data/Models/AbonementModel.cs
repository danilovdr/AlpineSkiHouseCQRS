using AlpineSkiHouseCQRS.Domain;
using System.Collections.Generic;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class AbonementModel : Abonement
    {
        public List<UserAbonementModel> UserAbonement { get; set; }
    }
}
