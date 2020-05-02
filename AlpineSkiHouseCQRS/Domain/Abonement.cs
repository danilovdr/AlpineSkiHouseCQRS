using System;

namespace AlpineSkiHouseCQRS.Domain
{
    public class Abonement
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DaysDuration { get; set; }
        public AbonementType Type { get; set; }
        public int Cost { get; set; }
    }
}
