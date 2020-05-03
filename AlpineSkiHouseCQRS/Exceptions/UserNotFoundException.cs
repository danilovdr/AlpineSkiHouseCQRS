namespace AlpineSkiHouseCQRS.Exceptions
{
    public class UserNotFoundException : SkiHouseException
    {
        public UserNotFoundException(string message)
            :base(message)
        {
        }
    }
}
