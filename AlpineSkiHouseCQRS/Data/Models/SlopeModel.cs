using AlpineSkiHouseCQRS.Domain;
using System;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class SlopeModel : Slope
    {
        public Guid ZoneId { get; set; }
        public ZoneModel Zone { get; set; }
    }
}
