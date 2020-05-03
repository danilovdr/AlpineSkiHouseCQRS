namespace AlpineSkiHouseCQRS.Exceptions
{
    public class UserAbonementNotFoundException : SkiHouseException
    {
        public UserAbonementNotFoundException(string message)
            :base(message)
        { }
    }
}
