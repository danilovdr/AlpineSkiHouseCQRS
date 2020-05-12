using AlpineSkiHouseCQRS.Domain;
using System.Collections.Generic;

namespace AlpineSkiHouseCQRS.Data.Models
{
    public class ZoneModel : Zone
    {
        public List<SlopeModel> Slopes { get; set; }
    }
}
