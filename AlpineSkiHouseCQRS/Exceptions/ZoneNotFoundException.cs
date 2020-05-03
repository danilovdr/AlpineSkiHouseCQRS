namespace AlpineSkiHouseCQRS.Exceptions
{
    public class ZoneNotFoundException : SkiHouseException
    {
        public ZoneNotFoundException(string message)
            : base(message)
        { }
    }
}
