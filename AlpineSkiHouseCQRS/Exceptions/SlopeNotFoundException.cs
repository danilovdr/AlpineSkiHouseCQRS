namespace AlpineSkiHouseCQRS.Exceptions
{
    public class SlopeNotFoundException : SkiHouseException
    {
        public SlopeNotFoundException(string message)
            :base(message)
        { }
    }
}
